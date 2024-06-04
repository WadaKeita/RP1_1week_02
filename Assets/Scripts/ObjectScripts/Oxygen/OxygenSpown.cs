using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class OxygenSpown : MonoBehaviour
{
    //シード値の指定
    //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    //float型で指定する
    //UnityEngine.Random.Range(0f,10.0f);//0以上10以下までのflaot型の値を返す
    //int型で指定する
    //UnityEngine.Random.Range(0,10);//0以上10未満のint型の値を返す

    public GameObject oxygenPrefab;

    #region var-Spown
    [Header("スポーン")]
    [SerializeField] public float spownDelay = 1.0f;    // 秒
    [SerializeField] public float currentTime = 0;    // 今の時間
    [SerializeField] private const float spownDelayMin = 0.5f; // 最短/秒
    [SerializeField] private const float spownDelayMax = 4.0f; // 最長/秒
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
        GameObject obj = MovementRange.movementRange;
        var circlePos = obj.transform.localScale.x / 2.0f * UnityEngine.Random.insideUnitCircle;

        // XZ平面で指定された半径、中心点の円内のランダム位置を計算
        var spawnPos = new Vector3(
            circlePos.x, circlePos.y, 0
        );


        // すでにあるオブジェクトとの接触判定を取る(blackHole / Player)
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

        // 接触していたら別の場所に生成する
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

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
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
            currentTime += Time.deltaTime;
            if (currentTime >= spownDelay)
            {
                currentTime = 0;

                // 次のクールタイムをセット
                UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                spownDelay = UnityEngine.Random.Range(spownDelayMin, spownDelayMax);

                // ランダム生成
                SpownOxygen();
            }
        }
    }
}
