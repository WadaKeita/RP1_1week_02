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
    [Header("���ԊǗ�")]
    [SerializeField] public float timeLimit;  // ��������(�b)
    [SerializeField] public float increaseTime;  // �u���b�N�z�[���ɂ�鑝������
    [SerializeField] public float elapsedTime;  // ���݂̌o�ߎ���
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

            // �o�ߎ��Ԃ��������Ԃ������Ă��邩
            if (timeLimit <= elapsedTime)
            {
                // �z���Ă�����isClear��true�ɂ���
                elapsedTime = timeLimit;
                gameManager.GetComponent<GameManager>().SetIsEnd(true);
            }

            Timetext.text = "" + Mathf.Ceil(timeLimit - elapsedTime);
        }

        Insekitext.transform.position = new Vector3(pos - +((250 / timeLimit) * elapsedTime), Insekitext.transform.position.y, Insekitext.transform.position.z);
    }
}
