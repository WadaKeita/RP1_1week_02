using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 出現したポジション
    public Vector3 InitialPosition;
    [SerializeField] public float moveSpeed = 3.0f;  // 移動速度

    [SerializeField] public float stealTime = 5.0f;  // ブラックホールに辿り着いて酸素を取るまでの時間
    [SerializeField] public float currentTime = 0;
    float moveDistance;
    float escapeDistance;

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
        InitialPosition = this.transform.position;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "BlackHole")
        {
            nowState = Status.STEAL;
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

                heading = new Vector3(0, 0, 0) - InitialPosition;
                moveDistance = heading.magnitude;
                heading = new Vector3(0, 0, 0) - transform.position;
                escapeDistance = heading.magnitude;

                heading = transform.position - new Vector3(0, 0, 0);
                var distance = heading.magnitude;
                direction = heading / escapeDistance;

                moveVelocity = direction * moveSpeed;

                GetComponent<Rigidbody2D>().velocity = moveVelocity;

                if(escapeDistance > moveDistance)
                {
                    Destroy(gameObject);
                }

                break;
        }
    }
}
