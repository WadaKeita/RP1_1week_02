using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    //[Header("酸素")]
    #endregion

    private void OnTriggerStay2D(Collider2D collision)
    {
        // ブラックホールに当たったらスコアになる
        if (collision.gameObject.tag == ("BlackHole"))
        {
            // スコアを増加
            GameObject obj = ScoreManager.scoreManager;
            obj.GetComponent<ScoreManager>().ScoreUP();

            // 納品数を増加
            obj = OxygenManager.oxyManager;
            obj.GetComponent<OxygenManager>().OxygenNumUP();

            // ブラックホールのチャージを増加
            obj = BlackHole.blackHole;
            obj.GetComponent<BlackHole>().ChargePercentageUP();

            // 自分を削除
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isConnect = false;
    }

    public bool GetIsConnect() { return isConnect; }
    public void SetIsConnect(bool connect) { isConnect = connect; }


    // Update is called once per frame
    void Update()
    {

    }
}
