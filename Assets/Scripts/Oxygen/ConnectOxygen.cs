using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public GameObject connectOxygenPrefab;
    public GameObject oxygenPrefab;
    public GameObject gameManager;

    public bool isPlayerConnect;
    //public bool isOxygenConnect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
        isPlayerConnect = false;
        //isOxygenConnect = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("BlackHole"))
        {
            isPlayerConnect = false;

            gameManager.GetComponent<GameManager>().ScoreUP();

            OxygenManager.OxygenList.Remove(this.gameObject);
            // 自分を削除
            Destroy(this.gameObject);
        }

        //isPlayerConnect = false;
        //if (collision.gameObject.tag == ("Player"))
        //{
        //    isPlayerConnect = true;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //// ブラックホールに当たったらスコアになる
        //if (collision.gameObject.tag == ("BlackHole"))
        //{
        //    isPlayerConnect = false;

        //    gameManager.GetComponent<GameManager>().ScoreUP();

        //    OxygenManager.OxygenList.Remove(this.gameObject);
        //    // 自分を削除
        //    Destroy(this.gameObject);
        //}


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectOxygen")
        {
            Debug.Log("離れた！");
        }
    }

    public bool GetIsPlayerConnect()
    {
        return isPlayerConnect;
    }
    public void SetIsPlayerConnect(bool isConnect)
    {
        isPlayerConnect = isConnect;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerConnect)
        {
            Debug.Log("つながりを感じる");
        }

        //GameObject[] oxygens = null;
        //if (oxygens == null)
        //{
        //    oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        //}
        //foreach (GameObject oxygen in oxygens)
        //{
        //    float distance;
        //    distance = Vector2.Distance(oxygen.transform.position, this.gameObject.transform.position);
        //    float radius = (this.gameObject.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

        //    if (distance <= radius)
        //    {
        //        // プレイヤーに付いている酸素を作成
        //        GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);
        //        // 酸素を削除
        //        Destroy(oxygen.gameObject);

        //        // 酸素の情報をスタックする
        //        OxygenManager.OxygenList.Add(clone.gameObject);
        //    }
        //}

        //// 酸素に当たったら当たった酸素が繋がる
        //if (collision.gameObject.tag == ("Oxygen") && collision.GetComponent<Oxygen>().GetIsConnect() == false)
        //{
        //    collision.GetComponent<Oxygen>().SetIsConnect(true);

        //    //// 位置のずれを修正する、プレイヤーにぴったり張り付くように
        //    //Vector3 direction = Vector3.zero;
        //    //if (collision.gameObject.transform.position != this.transform.position)
        //    //{
        //    //    direction = collision.gameObject.transform.position - this.transform.position;
        //    //    direction = direction.normalized;
        //    //}
        //    //Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    //collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //}

        //if (isPlayerConnect == false)
        //{
        //    // 離れた酸素を通常酸素にする
        //    GameObject clone = Instantiate(oxygenPrefab, this.gameObject.transform.position, Quaternion.identity);

        //    OxygenManager.OxygenList.Remove(this.gameObject);

        //    // 繋がっている酸素を削除
        //    Destroy(this.gameObject);
        //}
    }
}
