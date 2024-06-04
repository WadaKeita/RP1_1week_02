using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // ���̃X�N���v�g�Ŏ_�f�̏o�����Ǘ�����

    public GameObject oxygenPrefab;
    public GameObject connectOxygenPrefab;
    public GameObject attackOxygenPrefab;

    public GameObject player;

    #region var-Oxygen
    [Header("�_�f�Ǘ�")]
    public int maxNumber = 10;  // �_�f�̍ő吔
    public static int currentNumber = 0;  // ���݂̌�
    #endregion

    // ���������_�f�̏������X�g�ɓ����
    public static List<GameObject> OxygenList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        GameObject[] oxygens = null;
        if (oxygens == null)
        {
            oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        }
        foreach (GameObject oxygen in oxygens)
        {
            float distance = Vector2.Distance(player.transform.position, oxygen.transform.position);
            float radius = (player.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

            if (distance <= radius)
            {
                if (oxygen != null && oxygen.GetComponent<Oxygen>().GetIsConnect() == false)
                {
                    // �v���C���[�ɕt���Ă���_�f���쐬
                    GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);

                    oxygen.GetComponent<Oxygen>().SetIsConnect(true);

                    // �_�f���폜
                    Destroy(oxygen.gameObject);

                    // �_�f�̏����X�^�b�N����
                    OxygenList.Add(clone.gameObject);

                    Debug.Log("�����ő��������@");
                }
            }
        }

        GameObject[] connects = null;
        if (connects == null)
        {
            connects = GameObject.FindGameObjectsWithTag("ConnectOxygen");
        }
        foreach (GameObject connect in connects)
        {
            GameObject[] oxys = null;
            if (oxys == null)
            {
                oxys = GameObject.FindGameObjectsWithTag("Oxygen");
            }
            foreach (GameObject oxy in oxys)
            {
                float distance;
                distance = Vector2.Distance(connect.transform.position, oxy.gameObject.transform.position);
                float radius = (connect.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);

                if (distance <= radius)
                {
                    if (oxy != null && oxy.GetComponent<Oxygen>().GetIsConnect() == false)
                    {
                        // �v���C���[�ɕt���Ă���_�f���쐬
                        GameObject clone = Instantiate(connectOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                        oxy.GetComponent<Oxygen>().SetIsConnect(true);

                        // �_�f���폜
                        Destroy(oxy.gameObject);

                        // �_�f�̏����X�^�b�N����
                        OxygenList.Add(clone.gameObject);
                        Debug.Log("�����ő��������A");
                    }
                }
            }
        }

        // �q�����Ă�_�f�����̔�������߂�
        if (OxygenList.Count > 0)
        {

            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);
            }
            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];

                // �v���C���[�ƂԂ����Ă�����v���C���[�R�l�N�g��true�ɂ���
                float distance = Vector2.Distance(player.transform.position, oxy.transform.position);
                float radius = (player.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }

                for (int j = 0; j < OxygenList.Count; j++)
                {
                    GameObject oxygen = OxygenList[j];

                    if (oxy != oxygen)
                    {
                        distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                        radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                        if (distance <= radius)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                            {
                                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                Debug.Log(oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect());
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                if (!oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                {
                    // ���ꂽ�_�f��ʏ�_�f�ɂ���
                    GameObject clone = Instantiate(attackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenList.Remove(oxy.gameObject);

                    Vector3 direction = Vector3.zero;
                    if (clone.transform.position != player.transform.position)
                    {
                        direction = clone.transform.position - player.transform.position;
                        direction = direction.normalized;
                    }
                    clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;

                    // �q�����Ă���_�f���폜
                    Destroy(oxy.gameObject);
                }
            }
        }
    }
}
