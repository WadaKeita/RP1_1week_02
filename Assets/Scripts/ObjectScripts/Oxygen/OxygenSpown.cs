using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class OxygenSpown : MonoBehaviour
{
    //�V�[�h�l�̎w��
    //UnityEngine.Random.InitState(DateTime.Now.Millisecond);
    //float�^�Ŏw�肷��
    //UnityEngine.Random.Range(0f,10.0f);//0�ȏ�10�ȉ��܂ł�flaot�^�̒l��Ԃ�
    //int�^�Ŏw�肷��
    //UnityEngine.Random.Range(0,10);//0�ȏ�10������int�^�̒l��Ԃ�

    public GameObject oxygenPrefab;

    #region var-Spown
    [Header("�X�|�[��")]
    [SerializeField] public float spownDelay = 1.0f;    // �b
    [SerializeField] public float currentTime = 0;    // ���̎���
    [SerializeField] private const float spownDelayMin = 0.5f; // �ŒZ/�b
    [SerializeField] private const float spownDelayMax = 4.0f; // �Œ�/�b
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
        GameObject obj = MovementRange.movementRange;
        var circlePos = obj.transform.localScale.x / 2.0f * UnityEngine.Random.insideUnitCircle;

        // XZ���ʂŎw�肳�ꂽ���a�A���S�_�̉~���̃����_���ʒu���v�Z
        var spawnPos = new Vector3(
            circlePos.x, circlePos.y, 0
        );


        // ���łɂ���I�u�W�F�N�g�Ƃ̐ڐG��������(blackHole / Player)
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

        // �ڐG���Ă�����ʂ̏ꏊ�ɐ�������
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

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
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
            currentTime += Time.deltaTime;
            if (currentTime >= spownDelay)
            {
                currentTime = 0;

                // ���̃N�[���^�C�����Z�b�g
                UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                spownDelay = UnityEngine.Random.Range(spownDelayMin, spownDelayMax);

                // �����_������
                SpownOxygen();
            }
        }
    }
}
