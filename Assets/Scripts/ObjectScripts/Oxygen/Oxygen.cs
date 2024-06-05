using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    //[Header("�_�f")]
    #endregion

    private void OnTriggerStay2D(Collider2D collision)
    {
        // �u���b�N�z�[���ɓ���������X�R�A�ɂȂ�
        if (collision.gameObject.tag == ("BlackHole"))
        {
            // �X�R�A�𑝉�
            GameObject obj = ScoreManager.scoreManager;
            obj.GetComponent<ScoreManager>().ScoreUP();

            // �[�i���𑝉�
            obj = OxygenManager.oxyManager;
            obj.GetComponent<OxygenManager>().OxygenNumUP();

            // �u���b�N�z�[���̃`���[�W�𑝉�
            obj = BlackHole.blackHole;
            obj.GetComponent<BlackHole>().ChargePercentageUP();

            // �������폜
            Destroy(this.gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        isConnect = false;
    }

    public bool GetIsConnect() { return isConnect; }
    public void SetIsConnect(bool connect) { isConnect = connect; }


    // Update is called once per frame
    void Update()
    {

    }
}
