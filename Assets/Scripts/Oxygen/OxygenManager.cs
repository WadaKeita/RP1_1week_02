using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // このスクリプトで酸素の出現を管理する

    public GameObject oxygenPrefab;
    public GameObject connectOxygenPrefab;
    public GameObject attackOxygenPrefab;

    public GameObject player;

    #region var-Oxygen
    [Header("酸素管理")]
    public int maxNumber = 10;  // 酸素の最大数
    public static int currentNumber = 0;  // 現在の個数
    #endregion

    // くっついた酸素の情報をリストに入れる
    public static List<GameObject> OxygenList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        GameObject[] oxygens = null;
        if (oxygens == null)
        {
            oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        }
        foreach (GameObject oxygen in oxygens)
        {
            float distance = Vector2.Distance(player.transform.position, oxygen.transform.position);
            float radius = (player.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

            if (distance <= radius)
            {
                if (oxygen != null && oxygen.GetComponent<Oxygen>().GetIsConnect() == false)
                {
                    // プレイヤーに付いている酸素を作成
                    GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);

                    oxygen.GetComponent<Oxygen>().SetIsConnect(true);

                    // 酸素を削除
                    Destroy(oxygen.gameObject);

                    // 酸素の情報をスタックする
                    OxygenList.Add(clone.gameObject);

                    Debug.Log("ここで増えたんよ�@");
                }
            }
        }

        GameObject[] connects = null;
        if (connects == null)
        {
            connects = GameObject.FindGameObjectsWithTag("ConnectOxygen");
        }
        foreach (GameObject connect in connects)
        {

            GameObject[] oxys = null;
            if (oxys == null)
            {
                oxys = GameObject.FindGameObjectsWithTag("Oxygen");
            }
            foreach (GameObject oxy in oxys)
            {
                float distance;
                distance = Vector2.Distance(connect.transform.position, oxy.gameObject.transform.position);
                float radius = (connect.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);

                if (distance <= radius)
                {
                    if (oxy != null && oxy.GetComponent<Oxygen>().GetIsConnect() == false)
                    {
                        // プレイヤーに付いている酸素を作成
                        GameObject clone = Instantiate(connectOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                        oxy.GetComponent<Oxygen>().SetIsConnect(true);

                        // 酸素を削除
                        Destroy(oxy.gameObject);

                        // 酸素の情報をスタックする
                        OxygenList.Add(clone.gameObject);
                        Debug.Log("ここで増えたんよ�A");
                    }
                }
            }
        }



        // 繋がってる酸素たちの判定を求める
        if (OxygenList.Count > 0)
        {
            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);

                // プレイヤーとぶつかっていたらプレイヤーコネクトをtrueにする
                float distance = Vector2.Distance(player.transform.position, oxy.transform.position);
                float radius = (player.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }

                for (int j = 0; j < OxygenList.Count; j++)
                {
                    GameObject oxygen = OxygenList[j];

                    if (oxy != oxygen)
                    {
                        distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                        radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                        if (distance <= radius)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                            {
                                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                Debug.Log(oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect());
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                if (!oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                {
                    // 離れた酸素を通常酸素にする
                    GameObject clone = Instantiate(attackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenList.Remove(oxy.gameObject);

                    Vector3 direction = Vector3.zero;
                    if (clone.transform.position != player.transform.position)
                    {
                        direction = clone.transform.position - player.transform.position;
                        direction = direction.normalized;
                    }
                    clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;

                    // 繋がっている酸素を削除
                    Destroy(oxy.gameObject);
                    Debug.Log("SKUJO!!!!");

                }
            }
        }



        //if (OxygenList.Count > 0)
        //{
        //    for (int i = 0; i < OxygenList.Count; i++)
        //    {
        //        GameObject oxy = OxygenManager.OxygenList[i];
        //        bool isConnectOxy = oxy.gameObject.GetComponent<ConnectOxygen>().GetIsPlayerConnect();
        //        if (isConnectOxy == false)
        //        {

        //            for (int j = 0; j < OxygenList.Count; j++)
        //            {
        //                GameObject oxygen = OxygenManager.OxygenList[j];

        //                if (oxygen.gameObject != oxy.gameObject)
        //                {
        //                    bool isConnectOxygen = oxygen.gameObject.GetComponent<ConnectOxygen>().GetIsPlayerConnect();

        //                    if (isConnectOxygen == true)
        //                    {
        //                        float distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
        //                        float radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
        //                        if (distance <= radius)
        //                        {
        //                            oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);

        //                            break;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //}

        //if (OxygenList.Count > 0)
        //{
        //    for (int i = 0; i < OxygenList.Count; i++)
        //    {
        //        //Debug.Log(OxygenList[i]);

        //        GameObject oxy = OxygenManager.OxygenList[i];
        //        bool isConnectOxy = oxy.gameObject.GetComponent<ConnectOxygen>().GetIsPlayerConnect();

        //        if (isConnectOxy == false)
        //        {
        //            // 離れた酸素を通常酸素にする
        //            GameObject clone = Instantiate(attackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

        //            OxygenManager.OxygenList.Remove(oxy.gameObject);

        //            Vector3 direction = Vector3.zero;
        //            if (clone.transform.position != Player.player.transform.position)
        //            {
        //                direction = clone.transform.position - Player.player.transform.position;
        //                direction = direction.normalized;
        //            }
        //            clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 5;



        //            // 繋がっている酸素を削除
        //            Destroy(oxy.gameObject);
        //            Debug.Log("SKUJO!!!!");
        //        }
        //    }
        //}
    }
}
