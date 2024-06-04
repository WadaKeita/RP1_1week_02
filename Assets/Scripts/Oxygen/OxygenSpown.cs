using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class OxygenSpown : MonoBehaviour
{
    //シード値の指定
    //UnityEngin.Random.InitState(DateTime.Now.Millisecond);
    //float型で指定する
    //UnityEngin.Random.Range(0f,10.0f);//0以上10以下までのflaot型の値を返す
    //int型で指定する
    //UnityEngin.Random.Range(0,10);//0以上10未満のint型の値を返す

    public GameObject oxygenPrefab;

    #region var-Spown
    [Header("スポーン")]
    [SerializeField] public float spownDelay = 1.0f;
    #endregion

    bool isStartSpown = false;

    // Start is called before the first frame update
    void Start()
    {
        isStartSpown = true;
    }

    // ランダムな場所に酸素を生成する
    public void SpownOxygen()
    {
        //// 現在の時間からシード値を入手
        //UnityEngine.Random.InitState(DateTime.Now.Millisecond);

        //// 0,1で-か+を判断
        //UnityEngine.Random.Range(0, 2);//0以上2未満のint型の値を返す

        //// ブラックホールの直径から円の外周までの範囲
        //UnityEngine.Random.Range(BlackHole.blackHole.gameObject.transform.localScale.x, MovementRange.movementRange.transform.localScale.x / 2.0f);
        // 指定された半径の円内のランダム位置を取得

        GameObject obj = MovementRange.movementRange;
        var circlePos = obj.transform.localScale.x / 2.0f * UnityEngine.Random.insideUnitCircle;

        // XZ平面で指定された半径、中心点の円内のランダム位置を計算
        var spawnPos = new Vector3(
            circlePos.x, circlePos.y, 0
        );

        bool isObjectCollision = false;

        float distance;
        float radius;
        obj = BlackHole.blackHole;
        distance = Vector2.Distance(obj.transform.position, spawnPos);
        radius = (obj.transform.localScale.x / 2) + (oxygenPrefab.transform.localScale.x / 2);

        if (distance <= radius) { isObjectCollision = true; }

        obj = Player.player;
        distance = Vector2.Distance(obj.transform.position, spawnPos);
        radius = (obj.transform.localScale.x / 2) + (oxygenPrefab.transform.localScale.x / 2);

        if (distance <= radius) { isObjectCollision = true; }


        if (isObjectCollision)
        {
            SpownOxygen();
            return;
        }
        // Prefabを追加
        Instantiate(oxygenPrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (isStartSpown)
        {
            for (int i = 0; i < 10; i++)
            {
                SpownOxygen();
            }
            isStartSpown = false;
        }
        // クールタイムの計算

        // ランダム生成

        // 次のクールタイムをセット
    }
}
