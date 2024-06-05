using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine.UI;
using UnityEngine;

public class Result : MonoBehaviour
{
    public Image clearTexture;          // フェード用のUIパネル（Image）
    public Image gameOverTexture;       // フェード用のUIパネル（Image）

    public bool resultJudgement;

    enum ScoreResult
    {
        CLEAR,
        GAMEOVER,
    }

    ScoreResult result;


    // Start is called before the first frame update
    void Start()
    {
        resultJudgement = false;
    }

    // Update is called once per frame
    void Update()
    {
        GameObject obj = GameManager.gameManager;
        if (obj.GetComponent<GameManager>().isEnd)
        {
            if (obj.GetComponent<GameManager>().isClear == true && resultJudgement == false)
            {
                result = ScoreResult.CLEAR;
                resultJudgement = true;
            }
            else
            {
                result = ScoreResult.GAMEOVER;
                resultJudgement = true;
            }

            switch (result)
            {
                case ScoreResult.CLEAR:

                    clearTexture.enabled = true;

                    break;

                case ScoreResult.GAMEOVER:

                    gameOverTexture.enabled = true;

                    break;
            }
        }
    }
}
