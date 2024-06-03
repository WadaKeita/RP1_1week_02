using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text Timetext;

    #region var-Time
    [Header("時間管理")]
    [SerializeField] public float timeLimit;  // 制限時間(秒)
    [SerializeField] public float increaseTime;  // ブラックホールによる増加時間
    [SerializeField] public float elapsedTime;  // 現在の経過時間
    #endregion

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Timetext.text = "Time：" + timeLimit;

        gameManager = GameManager.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().GetIsClear() == false)
        {
            elapsedTime += Time.deltaTime;

            // 経過時間が制限時間をこえているか
            if (timeLimit <= elapsedTime)
            {
                // 越えていたらisClearをtrueにする
                elapsedTime = timeLimit;
                gameManager.GetComponent<GameManager>().SetIsClear(true);
            }

            Timetext.text = "Time：" + Mathf.Ceil(timeLimit - elapsedTime);
        }
    }
}
