using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // ���̃X�N���v�g�Ŏ_�f�̏o�����Ǘ�����

    public GameObject oxygenPrefab;

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

    }

    // Update is called once per frame
    void LateUpdate()
    {

        // �q�����Ă�_�f�����̔�������߂�
        if (OxygenList.Count > 0)
        {
            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                float distance;
                distance = Vector2.Distance(oxy.transform.position, player.gameObject.transform.position);
                float radius = (player.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }
            }



            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];
                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {

                    for (int j = 0; j < OxygenList.Count; j++)
                    {
                        GameObject oxygen = OxygenList[j];

                        if (oxygen.gameObject != oxy.gameObject)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == true)
                            {
                                float distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                                float radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                                if (distance <= radius)
                                {
                                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {
                    // ���ꂽ�_�f��ʏ�_�f�ɂ���
                    GameObject clone = Instantiate(oxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenManager.OxygenList.Remove(oxy.gameObject);

                    // �q�����Ă���_�f���폜
                    Destroy(oxy.gameObject);
                }
            }
        }
    }
}
