using System.Collections;
using System.Collections.Generic;
using System.Threading;
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
    public int targetNumber = 100;  // 納品の目標数
    public int getNumber = 0;  // 納品した数
    public int fieldMaxNumber = 30;  // 酸素の最大数
    public int currentNumber = 0;  // 現在の個数
    #endregion

    public static int targetNum;
    public static int fieldMax;
    public static GameObject oxyManager;

    // くっついた酸素の情報をリストに入れる
    public static List<GameObject> OxygenList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        OxygenList.Clear();

        oxyManager = this.gameObject;
        fieldMax = fieldMaxNumber;
        targetNum = targetNumber;
    }

    public int CountOxygen()
    {
        currentNumber = 0;

        // 通常酸素の数
        GameObject[] oxys = null;
        if (oxys == null)
        {
            oxys = GameObject.FindGameObjectsWithTag("Oxygen");
        }
        foreach (GameObject oxy in oxys)
        {
            currentNumber++;
        }

        // 攻撃酸素の数
        oxys = null;
        if (oxys == null)
        {
            oxys = GameObject.FindGameObjectsWithTag("AttackOxygen");
        }
        foreach (GameObject oxy in oxys)
        {
            currentNumber++;
        }

        // 接続酸素の数
        oxys = null;
        if (oxys == null)
        {
            oxys = GameObject.FindGameObjectsWithTag("ConnectOxygen");
        }
        foreach (GameObject oxy in oxys)
        {
            currentNumber++;
        }

        return currentNumber;
    }

    public void OxygenNumUP()
    {
        getNumber++;
    }
    public void OxygenNumDOWN()
    {
        getNumber--;
        if (getNumber < 0)
        {
            getNumber = 0;
        }
    }

    public int GetGetNumber()
    {
        return getNumber;
    }


    // Update is called once per frame
    void LateUpdate()
    {
        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
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

                        //Debug.Log("ここで増えたんよ�@");
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
                            //Debug.Log("ここで増えたんよ�A");
                        }
                    }
                }
            }

            // 繋がってる酸素たちの判定を求める
            if (OxygenList.Count > 0)
            {

                for (int i = 0; i < OxygenList.Count; i++)
                {
                    GameObject oxy = OxygenList[i];

                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);
                }
                for (int i = 0; i < OxygenList.Count; i++)
                {
                    GameObject oxy = OxygenList[i];

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
                    }
                }
            }
        }
    }
}
