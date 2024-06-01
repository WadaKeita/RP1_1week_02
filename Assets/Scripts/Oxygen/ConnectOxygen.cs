using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public GameObject connectOxygenPrefab;
    public GameObject oxygenPrefab;
    public GameObject gameManager;

    public static bool isPlayerConnect;
    //public bool isOxygenConnect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
        isPlayerConnect = false;
        //isOxygenConnect = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("BlackHole"))
        {
            isPlayerConnect = false;

            gameManager.GetComponent<GameManager>().ScoreUP();

            OxygenManager.OxygenList.Remove(this.gameObject);
            // �������폜
            Destroy(this.gameObject);
        }

        //isPlayerConnect = false;
        //if (collision.gameObject.tag == ("Player"))
        //{
        //    isPlayerConnect = true;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //// �u���b�N�z�[���ɓ���������X�R�A�ɂȂ�
        //if (collision.gameObject.tag == ("BlackHole"))
        //{
        //    isPlayerConnect = false;

        //    gameManager.GetComponent<GameManager>().ScoreUP();

        //    OxygenManager.OxygenList.Remove(this.gameObject);
        //    // �������폜
        //    Destroy(this.gameObject);
        //}


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectOxygen")
        {
            Debug.Log("���ꂽ�I");
        }
    }

    public bool GetIsPlayerConnect()
    {
        return isPlayerConnect;
    }
    public void SetIsPlayerConnect(bool isConnect)
    {
        isPlayerConnect = isConnect;
    }

    // Update is called once per frame
    void Update()
    {

        GameObject[] oxygens = null;
        if (oxygens == null)
        {
            oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        }
        foreach (GameObject oxygen in oxygens)
        {
            float distance;
            distance = Vector2.Distance(oxygen.transform.position, this.gameObject.transform.position);
            float radius = (this.gameObject.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

            if (distance <= radius)
            {
                // �v���C���[�ɕt���Ă���_�f���쐬
                GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);
                // �_�f���폜
                Destroy(oxygen.gameObject);

                // �_�f�̏����X�^�b�N����
                OxygenManager.OxygenList.Add(clone.gameObject);
            }
        }

        //// �_�f�ɓ��������瓖�������_�f���q����
        //if (collision.gameObject.tag == ("Oxygen") && collision.GetComponent<Oxygen>().GetIsConnect() == false)
        //{
        //    collision.GetComponent<Oxygen>().SetIsConnect(true);

        //    //// �ʒu�̂�����C������A�v���C���[�ɂ҂����蒣��t���悤��
        //    //Vector3 direction = Vector3.zero;
        //    //if (collision.gameObject.transform.position != this.transform.position)
        //    //{
        //    //    direction = collision.gameObject.transform.position - this.transform.position;
        //    //    direction = direction.normalized;
        //    //}
        //    //Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    //collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //}

        //if (isPlayerConnect == false)
        //{
        //    // ���ꂽ�_�f��ʏ�_�f�ɂ���
        //    GameObject clone = Instantiate(oxygenPrefab, this.gameObject.transform.position, Quaternion.identity);

        //    OxygenManager.OxygenList.Remove(this.gameObject);

        //    // �q�����Ă���_�f���폜
        //    Destroy(this.gameObject);
        //}
    }
}
