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
    public static Stack<GameObject> OxygenStack = new Stack<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
