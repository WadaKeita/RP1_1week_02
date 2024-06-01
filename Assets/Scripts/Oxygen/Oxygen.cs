using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    [Header("酸素")]
    #endregion

    public GameObject connectOxygenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        isConnect = false;
    }

    public bool GetIsConnect() { return isConnect; }
    public void SetIsConnect(bool connect) { isConnect = connect; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("Player") && isConnect == false)
        {
            isConnect = true;
            Debug.Log("付いた?");

            // 位置のずれを修正する、プレイヤーにぴったり張り付くように
            Vector3 direction = Vector3.zero;
            if (collision.gameObject.transform.position != this.transform.position)
            {
                direction = this.transform.position - collision.gameObject.transform.position;
                direction = direction.normalized;
            }
            Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
            this.transform.position = collision.gameObject.transform.position + Vector3.Scale(direction, kyori);

            // プレイヤーに付いている酸素を作成
            GameObject clone = Instantiate(connectOxygenPrefab, this.transform.position, Quaternion.identity);
            // 酸素を削除
            Destroy(this.gameObject);

            // 酸素の情報をスタックする
            OxygenManager.OxygenStack.Push(clone.gameObject);
        }


        //if (collision.gameObject.tag == ("Oxygen") &&
        //    collision.gameObject.GetComponent<Oxygen>().isConnect == false)
        //{
        //    collision.GetComponent<Oxygen>().isConnect = true;

        //    // 当たった酸素のinterlockスクリプトをOnにする
        //    var interlock = collision.GetComponent<InterlockPlayer>();
        //    interlock.enabled = true;
        //    //interlock.GetComponent<InterlockPlayer>().PosSet();


        //    // 位置のずれを修正する、酸素にぴったり張り付くように
        //    Vector3 direction = Vector3.zero;
        //    if (collision.gameObject.transform.position != this.transform.position)
        //    {
        //        direction = collision.gameObject.transform.position - this.transform.position;
        //        direction = direction.normalized;
        //    }
        //    Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //    // 酸素の情報をスタックする
        //    OxygenManager.OxygenStack.Push(collision.gameObject);

        //    Debug.Log("接触");
        //    Debug.Log(OxygenManager.OxygenStack.Count);
        //}

    }

    // Update is called once per frame
    void Update()
    {
        //rb.velocity = Vector3.zero;
    }
}
