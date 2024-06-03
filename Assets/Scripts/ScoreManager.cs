using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Scoretext;

    public static GameObject scoreManager;

    #region var-Score
    [Header("スコア管理")]
    [SerializeField] public float AcquisitionScore = 100;  // 獲得スコア
    [SerializeField] public float currentScore = 0;  // 現在のスコア
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        Scoretext.text = "Score：" + currentScore;

        scoreManager = this.gameObject;
    }

    public void ScoreUP()
    {
        currentScore += AcquisitionScore;
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score：" + currentScore;
    }
}
