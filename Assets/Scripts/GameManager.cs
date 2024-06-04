using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject movementRangePrefab;
    public GameObject blackHolePrefab;
    public GameObject blackHoleChargePrefab;

    public bool isEnd = false;

    public static GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //player.transform.position = new Vector3(0, 0, 0);
        // プレイヤーの生成
        Player.player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // 行動範囲の生成
        MovementRange.movementRange = Instantiate(movementRangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // ブラックホールの生成
        BlackHole.blackHole = Instantiate(blackHolePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        BlackHoleCharge.blackHoleCharge = Instantiate(blackHoleChargePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        gameManager = this.gameObject;
    }

    public void SetIsEnd(bool clear) { isEnd = clear; }
    public bool GetIsEnd() { return isEnd; }

    // Update is called once per frame
    void Update()
    {
        //if(isEnd)
        //{
        //    GameObject obj = FadeSceneLoader.fadeSceneLoader;
        //    StartCoroutine(obj.GetComponent<FadeSceneLoader>().FadeOutAndLoadScene());
        //}
        // プレイヤーの速度をゲームマネージャーで操作できるかテスト
        // player.GetComponent<Rigidbody2D>().velocity = Vector3.left;
    }
}
