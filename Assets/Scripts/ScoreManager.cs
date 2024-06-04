using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text Scoretext;

    #region var-Score
    [Header("�X�R�A�Ǘ�")]
    [SerializeField] public float increaseScore = 100;  // �l���X�R�A
    [SerializeField] public float currentScore = 0;  // ���݂̃X�R�A
    #endregion

    public static GameObject scoreManager;

    // Start is called before the first frame update
    void Start()
    {
        currentScore = 0;
        Scoretext.text = "Score �F" + currentScore;

        scoreManager = this.gameObject;
    }

    public void ScoreUP()
    {
        currentScore += increaseScore;
    }
    public void ScoreDOWN()
    {
        currentScore -= increaseScore;
        if(currentScore < 0) { currentScore = 0; }
    }

    // Update is called once per frame
    void Update()
    {
        Scoretext.text = "Score �F" + currentScore;
    }
}
