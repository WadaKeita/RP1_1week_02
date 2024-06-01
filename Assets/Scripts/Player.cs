using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player;

    #region var-Player
    [Header("�v���C���[")]
    [SerializeField] public float moveSpeed = 5.0f;  // �ړ����x
    [SerializeField] public Vector3 startPos = new Vector3(2, 2, 0);  // �ړ����x
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<GameObject>();
        player.transform.position = startPos;
    }


    private void PlayerMove()
    {
        // ---------- �ړ� ----------
        Vector3 moveVelocity = Vector3.zero;

        // --- �X�e�B�b�N���� ---
        if (Input.GetAxis("L_Stick_H") != 0 || Input.GetAxis("L_Stick_V") != 0)
        {
            // ���E�ړ�
            moveVelocity.x += moveSpeed * Input.GetAxis("L_Stick_H");

            // �㉺�ړ�
            moveVelocity.y += moveSpeed * Input.GetAxis("L_Stick_V");


            // �ړ����ɒn�ʂ��痣�ꂽ��W�����v���o���Ȃ��悤�ɂ���
            if (GetComponent<Rigidbody2D>().velocity.y < 0)
            {
                //isCanJump = false;
            }
        }
        else
        {
            // --- �L�[�{�[�h���� ---
            // �E�ړ�
            if (Input.GetKey(KeyCode.D))
            {
                //moveVelocity += moveSpeed;

                // �ړ����ɒn�ʂ��痣�ꂽ��W�����v���o���Ȃ��悤�ɂ���
                if (GetComponent<Rigidbody2D>().velocity.y < 0)
                {
                    //isCanJump = false;
                }
            }
            // ���ړ�
            if (Input.GetKey(KeyCode.A))
            {
                //moveVelocity += -moveSpeed;

                // �ړ����ɒn�ʂ��痣�ꂽ��W�����v���o���Ȃ��悤�ɂ���
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

        // ---------- �W�����v ----------
        //if (isCanJump == true && Input.GetKeyDown(KeyCode.Space) || // �L�[�{�[�h
        //    isCanJump == true && Input.GetKeyDown(KeyCode.JoystickButton0) // �R���g���[���[
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

        // �v���C���[�̃|�W�V������movementRange�̒��Ɏ��߂�
        transform.position = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);
    }
}
