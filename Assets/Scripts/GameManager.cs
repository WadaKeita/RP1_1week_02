using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject movementRangePrefab;
    public GameObject blackHolePrefab;

    public bool isClear = false;

    public static GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //player.transform.position = new Vector3(0, 0, 0);
        Player.player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        MovementRange.movementRange = Instantiate(movementRangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        BlackHole.blackHole = Instantiate(blackHolePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        gameManager = this.gameObject;
    }

    public void SetIsClear(bool clear) { isClear = clear; }
    public bool GetIsClear() { return isClear; }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの速度をゲームマネージャーで操作できるかテスト
        // player.GetComponent<Rigidbody2D>().velocity = Vector3.left;
    }
}
