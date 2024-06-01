using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player;

    #region var-Player
    [Header("プレイヤー")]
    [SerializeField] public float moveSpeed = 5.0f;  // 移動速度
    [SerializeField] public Vector3 startPos = new Vector3(2, 2, 0);  // 移動速度
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<GameObject>();
        player.transform.position = startPos;
    }


    private void PlayerMove()
    {
        // ---------- 移動 ----------
        Vector3 moveVelocity = Vector3.zero;

        // --- スティック操作 ---
        if (Input.GetAxis("L_Stick_H") != 0 || Input.GetAxis("L_Stick_V") != 0)
        {
            // 左右移動
            moveVelocity.x += moveSpeed * Input.GetAxis("L_Stick_H");

            // 上下移動
            moveVelocity.y += moveSpeed * Input.GetAxis("L_Stick_V");


            // 移動時に地面から離れたらジャンプが出来ないようにする
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                //isCanJump = false;
            }
        }
        else
        {
            // --- キーボード操作 ---
            // 右移動
            if (Input.GetKey(KeyCode.D))
            {
                //moveVelocity += moveSpeed;

                // 移動時に地面から離れたらジャンプが出来ないようにする
                if (GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    //isCanJump = false;
                }
            }
            // 左移動
            if (Input.GetKey(KeyCode.A))
            {
                //moveVelocity += -moveSpeed;

                // 移動時に地面から離れたらジャンプが出来ないようにする
                if (GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    //isCanJump = false;
                }
            }
        }

        GetComponent<Rigidbody2D>().velocity = moveVelocity;

        //if (transform.position.x + transform.localScale.x / 2 > Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x)
        //{

        //    transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(1, 0)).x - transform.localScale.x / 2 - 0.01f, transform.position.y, 0);
        //}
        //if (transform.position.x - transform.localScale.x / 2 < Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x)
        //{
        //    transform.position = new Vector3(Camera.main.ViewportToWorldPoint(new Vector2(0, 0)).x + (transform.localScale.x / 2) + 0.01f, transform.position.y, 0);

        //}
        // ------------------------------

        // ---------- ジャンプ ----------
        //if (isCanJump == true && Input.GetKeyDown(KeyCode.Space) || // キーボード
        //    isCanJump == true && Input.GetKeyDown(KeyCode.JoystickButton0) // コントローラー
        //    )
        //{
        //    playerRb.velocity = new Vector2(playerRb.velocity.x, jumpPower);
        //    isCanJump = false;
        //}
        // ------------------------------
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();

        // プレイヤーのポジションをmovementRangeの中に収める
        transform.position = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);
    }
}
