using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class OxygenSpown : MonoBehaviour
{
    //�V�[�h�l�̎w��
    //UnityEngin.Random.InitState(DateTime.Now.Millisecond);
    //float�^�Ŏw�肷��
    //UnityEngin.Random.Range(0f,10.0f);//0�ȏ�10�ȉ��܂ł�flaot�^�̒l��Ԃ�
    //int�^�Ŏw�肷��
    //UnityEngin.Random.Range(0,10);//0�ȏ�10������int�^�̒l��Ԃ�

    public GameObject oxygenPrefab;

    #region var-Spown
    [Header("�X�|�[��")]
    [SerializeField] public float spownDelay = 1.0f;
    #endregion

    bool isStartSpown = false;

    // Start is called before the first frame update
    void Start()
    {
        isStartSpown = true;
    }

    // �����_���ȏꏊ�Ɏ_�f�𐶐�����
    public void SpownOxygen()
    {
        //// ���݂̎��Ԃ���V�[�h�l�����
        //UnityEngine.Random.InitState(DateTime.Now.Millisecond);

        //// 0,1��-��+�𔻒f
        //UnityEngine.Random.Range(0, 2);//0�ȏ�2������int�^�̒l��Ԃ�

        //// �u���b�N�z�[���̒��a����~�̊O���܂ł͈̔�
        //UnityEngine.Random.Range(BlackHole.blackHole.gameObject.transform.localScale.x, MovementRange.movementRange.transform.localScale.x / 2.0f);
        // �w�肳�ꂽ���a�̉~���̃����_���ʒu���擾

        GameObject obj = MovementRange.movementRange;
        var circlePos = obj.transform.localScale.x / 2.0f * UnityEngine.Random.insideUnitCircle;

        // XZ���ʂŎw�肳�ꂽ���a�A���S�_�̉~���̃����_���ʒu���v�Z
        var spawnPos = new Vector3(
            circlePos.x, circlePos.y, 0
        );

        bool isObjectCollision = false;

        float distance;
        float radius;
        obj = BlackHole.blackHole;
        distance = Vector2.Distance(obj.transform.position, spawnPos);
        radius = (obj.transform.localScale.x / 2) + (oxygenPrefab.transform.localScale.x / 2);

        if (distance <= radius) { isObjectCollision = true; }

        obj = Player.player;
        distance = Vector2.Distance(obj.transform.position, spawnPos);
        radius = (obj.transform.localScale.x / 2) + (oxygenPrefab.transform.localScale.x / 2);

        if (distance <= radius) { isObjectCollision = true; }


        if (isObjectCollision)
        {
            SpownOxygen();
            return;
        }
        // Prefab��ǉ�
        Instantiate(oxygenPrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

        if (isStartSpown)
        {
            for (int i = 0; i < 10; i++)
            {
                SpownOxygen();
            }
            isStartSpown = false;
        }
        // �N�[���^�C���̌v�Z

        // �����_������

        // ���̃N�[���^�C�����Z�b�g
    }
}
