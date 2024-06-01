using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;

    public static GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        //player.transform.position = new Vector3(0, 0, 0);
        player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        // プレイヤーの速度をゲームマネージャーで操作できるかテスト
        // player.GetComponent<Rigidbody2D>().velocity = Vector3.left;
    }
}
