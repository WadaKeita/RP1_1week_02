using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // 出現したポジション
    [SerializeField] public float moveSpeed = 2.0f;  // 移動速度

    [SerializeField] public float stealTime = 5.0f;  // ブラックホールに辿り着いて酸素を取るまでの時間
    [SerializeField] public float currentTime = 0;
    [SerializeField] public float downSpeed = 0.9f;
    float moveDistance;
    float escapeDistance;

    public GameObject enemyDamagePrefab;
    public GameObject enemyOxygenPrefab;

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
            // ダメージを食らう敵のクローンを作成
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

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
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

                        // スコアを減少
                        GameObject obj = ScoreManager.scoreManager;
                        obj.GetComponent<ScoreManager>().ScoreDOWN();

                        // 納品数を減少
                        obj = OxygenManager.oxyManager;
                        obj.GetComponent<OxygenManager>().OxygenNumDOWN();

                        heading = new Vector3(0, 0, 0) - transform.position;
                        moveDistance = heading.magnitude;
                        direction = heading / moveDistance;
                        Vector3 clonePos = this.transform.position + direction * ((this.transform.localScale.x / 2) + (enemyOxygenPrefab.transform.localScale.x / 2));

                        // 敵の酸素を作成
                        GameObject clone = Instantiate(enemyOxygenPrefab, clonePos, Quaternion.identity);
                        clone.GetComponent<EnemyOxygen>().SetConnect(this.gameObject);
                        clone.GetComponent<InterlockEnemy>().SetEnemy(this.gameObject);
                    }

                    break;

                case Status.ESCAPE:

                    heading = new Vector3(0, 0, 0) - transform.position;
                    escapeDistance = heading.magnitude;

                    heading = transform.position - new Vector3(0, 0, 0);
                    var distance = heading.magnitude;
                    direction = heading / escapeDistance;

                    moveVelocity = direction * moveSpeed * downSpeed;

                    GetComponent<Rigidbody2D>().velocity = moveVelocity;

                    if (escapeDistance > MovementRange.movementRadius + this.transform.localScale.x)
                    {
                        Destroy(gameObject);
                    }

                    break;
            }
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
