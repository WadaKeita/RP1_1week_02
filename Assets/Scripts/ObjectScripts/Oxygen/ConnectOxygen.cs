using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public bool isPlayerConnect;
    //public bool isOxygenConnect;

    // Start is called before the first frame update
    void Start()
    {
        isPlayerConnect = false;
        //isOxygenConnect = false;
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == ("BlackHole"))
    //    {
    //        isPlayerConnect = false;

    //        // スコアを増加
    //        GameObject obj = ScoreManager.scoreManager;
    //        obj.GetComponent<ScoreManager>().ScoreUP();

    //        // ブラックホールのチャージを増加
    //        obj = BlackHole.blackHole;
    //        obj.GetComponent<BlackHole>().ChargePercentageUP();


    //        OxygenManager.OxygenList.Remove(this.gameObject);
    //        // 自分を削除
    //        Destroy(this.gameObject);
    //    }

    //}

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "ConnectOxygen")
    //    {
    //        Debug.Log("離れた！");
    //    }
    //}

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
        //if (isPlayerConnect)
        //{
        //    Debug.Log("つながりを感じる");
        //}
    }
}
