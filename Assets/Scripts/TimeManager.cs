using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text Timetext;

    public Image Insekitext;

    #region var-Time
    [Header("時間管理")]
    [SerializeField] public float timeLimit;  // 制限時間(秒)
    [SerializeField] public float increaseTime;  // ブラックホールによる増加時間
    [SerializeField] public float elapsedTime;  // 現在の経過時間
    #endregion

    //public GameObject gameManager;

    public static GameObject timeManager;
    float pos = 335.9f;

    // Start is called before the first frame update
    void Start()
    {
        Timetext.text = "" + timeLimit;

        //gameManager = GameManager.gameManager;

        timeManager = this.gameObject;
    }

    public void TimeIncrease() { timeLimit += increaseTime; }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            elapsedTime += Time.deltaTime;

            // 経過時間が制限時間をこえているか
            if (timeLimit <= elapsedTime)
            {
                // 越えていたらisClearをtrueにする
                elapsedTime = timeLimit;
                gameManager.GetComponent<GameManager>().SetIsEnd(true);
            }

            Timetext.text = "" + Mathf.Ceil(timeLimit - elapsedTime);
        }

        Insekitext.transform.position = new Vector3(pos - +((250 / timeLimit) * elapsedTime), Insekitext.transform.position.y, Insekitext.transform.position.z);
    }
}
