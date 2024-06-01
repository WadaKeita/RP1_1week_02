using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // このスクリプトで酸素の出現を管理する

    public GameObject oxygenPrefab;

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

    }

    // Update is called once per frame
    void LateUpdate()
    {

        // 繋がってる酸素たちの判定を求める
        if (OxygenList.Count > 0)
        {
            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                float distance;
                distance = Vector2.Distance(oxy.transform.position, player.gameObject.transform.position);
                float radius = (player.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }
            }



            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];
                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {

                    for (int j = 0; j < OxygenList.Count; j++)
                    {
                        GameObject oxygen = OxygenList[j];

                        if (oxygen.gameObject != oxy.gameObject)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == true)
                            {
                                float distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                                float radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                                if (distance <= radius)
                                {
                                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {
                    // 離れた酸素を通常酸素にする
                    GameObject clone = Instantiate(oxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenManager.OxygenList.Remove(oxy.gameObject);

                    // 繋がっている酸素を削除
                    Destroy(oxy.gameObject);
                }
            }
        }
    }
}
