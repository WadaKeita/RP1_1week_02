using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{

    public GameObject enemyPrefab;

    public float stopSpeed = 0.1f;

    public 
    // Start is called before the first frame update
    void Start()
    {
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "BlackHole")
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            if (GetComponent<Rigidbody2D>().velocity.x * GetComponent<Rigidbody2D>().velocity.x <= stopSpeed &&
            GetComponent<Rigidbody2D>().velocity.y * GetComponent<Rigidbody2D>().velocity.y <= stopSpeed)
            {
                // �G�̃N���[�����쐬
                GameObject clone = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
                Destroy(this.gameObject);
            }


            // �U���_�f�̃|�W�V������movementRange�̒��Ɏ��߂�
            Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

            // �[�����܂ōs������͂������
            if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(-tmp.x, GetComponent<Rigidbody2D>().velocity.y); }
            if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -tmp.y); }

            // �[�����܂ōs������~�܂�
            //if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y); }
            //if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); }

            transform.position = tmp;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
