using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using UnityEngine.UI;

public class TimeManager : MonoBehaviour
{
    public Text Timetext;

    #region var-Time
    [Header("���ԊǗ�")]
    [SerializeField] public float timeLimit;  // ��������(�b)
    [SerializeField] public float increaseTime;  // �u���b�N�z�[���ɂ�鑝������
    [SerializeField] public float elapsedTime;  // ���݂̌o�ߎ���
    #endregion

    GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        Timetext.text = "Time�F" + timeLimit;

        gameManager = GameManager.gameManager;
    }

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GetComponent<GameManager>().GetIsClear() == false)
        {
            elapsedTime += Time.deltaTime;

            // �o�ߎ��Ԃ��������Ԃ������Ă��邩
            if (timeLimit <= elapsedTime)
            {
                // �z���Ă�����isClear��true�ɂ���
                elapsedTime = timeLimit;
                gameManager.GetComponent<GameManager>().SetIsClear(true);
            }

            Timetext.text = "Time�F" + Mathf.Ceil(timeLimit - elapsedTime);
        }
    }
}
