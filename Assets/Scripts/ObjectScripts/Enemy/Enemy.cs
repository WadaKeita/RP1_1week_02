using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // �o�������|�W�V����
    [SerializeField] public float moveSpeed = 2.0f;  // �ړ����x

    [SerializeField] public float stealTime = 5.0f;  // �u���b�N�z�[���ɒH�蒅���Ď_�f�����܂ł̎���
    [SerializeField] public float currentTime = 0;
    float moveDistance;
    float escapeDistance;

    public GameObject enemyDamagePrefab;

    Status nowState;
    enum Status
    {
        MOVE,
        STEAL,
        ESCAPE,
    }

    // Start is called before the first frame update
    void Start()
    {
        nowState = Status.MOVE;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == ("AttackOxygen"))
        {
            // �_���[�W��H�炤�G�̃N���[�����쐬
            GameObject clone = Instantiate(enemyDamagePrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);

            Vector3 direction = Vector3.zero;

            if (clone.transform.position != collision.transform.position)
            {
                direction = clone.transform.position - collision.transform.position;
                direction = direction.normalized;
            }
            clone.GetComponent<Rigidbody2D>().velocity = direction * 5.0f;
        }

        if (collision.gameObject.tag == "BlackHole")
        {
            nowState = Status.STEAL;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "BlackHole")
        {
            if (nowState != Status.ESCAPE)
            {
                nowState = Status.MOVE;
                currentTime = 0;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (nowState)
        {
            case Status.MOVE:

                var heading = new Vector3(0, 0, 0) - transform.position;
                moveDistance = heading.magnitude;
                var direction = heading / moveDistance;

                Vector3 moveVelocity = direction * moveSpeed;

                GetComponent<Rigidbody2D>().velocity = moveVelocity;

                break;

            case Status.STEAL:

                currentTime += Time.deltaTime;
                if (currentTime > stealTime)
                {
                    nowState = Status.ESCAPE;
                }

                break;

            case Status.ESCAPE:

                heading = new Vector3(0, 0, 0) - transform.position;
                escapeDistance = heading.magnitude;

                heading = transform.position - new Vector3(0, 0, 0);
                var distance = heading.magnitude;
                direction = heading / escapeDistance;

                moveVelocity = direction * moveSpeed * 0.9f;

                GetComponent<Rigidbody2D>().velocity = moveVelocity;

                if (escapeDistance > MovementRange.movementRadius)
                {
                    Destroy(gameObject);
                }

                break;
        }
    }
}
