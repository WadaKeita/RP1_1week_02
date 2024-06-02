using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackOxygen : MonoBehaviour
{
    public GameObject oxygenPrefab;
    public GameObject gameManager;

    public float stopSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //attackRB.GetComponent<Rigidbody>();
        gameManager = GameManager.gameManager;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // �u���b�N�z�[���ɓ���������X�R�A�ɂȂ�
        if (collision.gameObject.tag == ("BlackHole"))
        {
            gameManager.GetComponent<GameManager>().ScoreUP();

            // �������폜
            Destroy(this.gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x * GetComponent<Rigidbody2D>().velocity.x <= 0.1f &&
            GetComponent<Rigidbody2D>().velocity.y * GetComponent<Rigidbody2D>().velocity.y <= 0.1f)
        {
            // �ʏ�_�f�̃N���[�����쐬
            GameObject clone = Instantiate(oxygenPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


        // �U���_�f�̃|�W�V������movementRange�̒��Ɏ��߂�
        Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

        // �[�����܂ōs������͂������
        //if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(-tmp.x, GetComponent<Rigidbody2D>().velocity.y); }
        //if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -tmp.y); }

        // �[�����܂ōs������~�܂�
        if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y); }
        if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); }

        transform.position = tmp;
    }
}
