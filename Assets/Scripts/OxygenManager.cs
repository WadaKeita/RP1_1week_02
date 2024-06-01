using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // このスクリプトで酸素の出現を管理する

    public GameObject oxygenPrefab;

    #region var-Oxygen
    [Header("酸素")]
    public int maxNumber = 10;  // 酸素の最大数
    public static int currentNumber = 0;  // 現在の個数
    #endregion

    // くっついた酸素の情報をリストに入れる
    public static Stack<GameObject> OxygenList = new Stack<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
