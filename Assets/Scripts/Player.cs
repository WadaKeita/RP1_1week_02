using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static GameObject player;
    public GameObject AttackOxygenPrefab;

    #region var-Player
    [Header("�v���C���[")]
    [SerializeField] public float moveSpeed = 5.0f;  // �ړ����x
    [SerializeField] public Vector3 startPos = new Vector3(2, 2, 0);  // �����ʒu
    [SerializeField] public float shotPower = 3.0f; // �_�f�������
    #endregion

    bool Rtrigger = false;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<GameObject>();
        player.transform.position = startPos;
    }

    private void OxygenShot(float power)
    {
        GameObject objTmp = OxygenManager.OxygenList[OxygenManager.OxygenList.Count - 1];
        OxygenManager.OxygenList.Remove(objTmp);
        // �U���_�f�̃N���[�����쐬
        GameObject clone = Instantiate(AttackOxygenPrefab, objTmp.transform.position, Quaternion.identity);
        Destroy(objTmp);

        Vector3 direction = Vector3.zero;
        if (clone.transform.position != this.transform.position)
        {
            direction = clone.transform.position - this.transform.position;
            direction = direction.normalized;
        }
        clone.GetComponent<Rigidbody2D>().velocity = direction * power;

        //// �������_�f��interlock�X�N���v�g��Off�ɂ���
        //var interlock = objTmp.GetComponent<InterlockPlayer>();
        //interlock.enabled = false;
    }

    // �_�f��S�������
    private void OxygenLetgo()
    {

        for (int i = OxygenManager.OxygenList.Count; i > 0; i--)
        {

            GameObject oxy = OxygenManager.OxygenList[i - 1];

            // ���ꂽ�_�f��ʏ�_�f�ɂ���
            GameObject clone = Instantiate(AttackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

            OxygenManager.OxygenList.Remove(oxy.gameObject);

            Vector3 direction = Vector3.zero;
            if (clone.transform.position != player.transform.position)
            {
                direction = clone.transform.position - player.transform.position;
                direction = direction.normalized;
            }
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;

            // �q�����Ă���_�f���폜
            Destroy(oxy.gameObject);
            Debug.Log("SKUJO!!!!");

        }
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
        //else
        //{
        //    // --- �L�[�{�[�h���� ---
        //    // �E�ړ�
        //    if (Input.GetKey(KeyCode.D))
        //    {
        //        //moveVelocity += moveSpeed;

        //        // �ړ����ɒn�ʂ��痣�ꂽ��W�����v���o���Ȃ��悤�ɂ���
        //        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        //        {
        //            //isCanJump = false;
        //        }
        //    }
        //    // ���ړ�
        //    if (Input.GetKey(KeyCode.A))
        //    {
        //        //moveVelocity += -moveSpeed;

        //        // �ړ����ɒn�ʂ��痣�ꂽ��W�����v���o���Ȃ��悤�ɂ���
        //        if (GetComponent<Rigidbody2D>().velocity.y < 0)
        //        {
        //            //isCanJump = false;
        //        }
        //    }
        //}

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

        if (Input.GetKeyDown(KeyCode.JoystickButton5))
        {
            if (OxygenManager.OxygenList.Count >= 1)
            {
                OxygenShot(shotPower);
            }
        }
        if (Input.GetKeyDown(KeyCode.JoystickButton2))
        {
            if (OxygenManager.OxygenList.Count >= 1)
            {
                OxygenLetgo();
            }
        }
        else if (Input.GetAxis("L_R_Trigger") > 0 && Rtrigger == false)
        {
            Rtrigger = true;
            if (OxygenManager.OxygenList.Count >= 1)
            {
                OxygenShot(shotPower);
            }
        }
        if (Input.GetAxis("L_R_Trigger") == 0 && Rtrigger == true)
        {
            Rtrigger = false;
        }

        // �v���C���[�̃|�W�V������movementRange�̒��Ɏ��߂�
        Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

        if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(-tmp.x, GetComponent<Rigidbody2D>().velocity.y); }
        if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -tmp.y); }

        transform.position = tmp;
    }
}
