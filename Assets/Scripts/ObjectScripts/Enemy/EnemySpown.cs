using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    public GameObject enemyPrefab;

    #region var-Spown
    [Header("スポーン")]
    [SerializeField] public float spownDelay = 10.0f;    // 秒
    [SerializeField] public float currentTime = 0;    // 今の時間
    [SerializeField] private float spownDelayMin = 5.0f; // 最短/秒
    [SerializeField] private float spownDelayMax = 15.0f; // 最長/秒
    #endregion

    //この条件なら円や角度は必要ないです
    //var vec:Vector3 = Vector3(Random.Range(0.1, 1.0), Random.Range(0.1, 1.0), Random.Range(0.1, 1.0)).normalized* r;
    //    ランダムなベクトルを生成
    //    Vector3(Random.Range(0.1, 1.0), Random.Range(0.1, 1.0), Random.Range(0.1, 1.0))
    //この値のnormalizedで距離１のランダムなベクトルを得ることが出来ます
    //そして半径rを掛けることで
    //位置0,0,0の半径r離れた円周上のランダムな位置になるので
    //中心にこの値vecを加算すれば
    //中心から半径r離れた円周上のランダムな位置が求まります

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SpownEnemy()
    {
        var spawnPos = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0).normalized * MovementRange.movementRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            // クールタイムの計算
            currentTime += Time.deltaTime;
            if (currentTime >= spownDelay)
            {
                currentTime = 0;

                // 次のクールタイムをセット
                UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                spownDelay = UnityEngine.Random.Range(spownDelayMin, spownDelayMax);

                // ランダム生成
                SpownEnemy();
            }
        }
    }
}
