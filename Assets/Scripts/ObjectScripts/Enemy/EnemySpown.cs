using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpown : MonoBehaviour
{
    public GameObject enemyPrefab;

    #region var-Spown
    [Header("�X�|�[��")]
    [SerializeField] public float spownDelay = 10.0f;    // �b
    [SerializeField] public float currentTime = 0;    // ���̎���
    [SerializeField] private float spownDelayMin = 5.0f; // �ŒZ/�b
    [SerializeField] private float spownDelayMax = 15.0f; // �Œ�/�b
    #endregion

    //���̏����Ȃ�~��p�x�͕K�v�Ȃ��ł�
    //var vec:Vector3 = Vector3(Random.Range(0.1, 1.0), Random.Range(0.1, 1.0), Random.Range(0.1, 1.0)).normalized* r;
    //    �����_���ȃx�N�g���𐶐�
    //    Vector3(Random.Range(0.1, 1.0), Random.Range(0.1, 1.0), Random.Range(0.1, 1.0))
    //���̒l��normalized�ŋ����P�̃����_���ȃx�N�g���𓾂邱�Ƃ��o���܂�
    //�����Ĕ��ar���|���邱�Ƃ�
    //�ʒu0,0,0�̔��ar���ꂽ�~����̃����_���Ȉʒu�ɂȂ�̂�
    //���S�ɂ��̒lvec�����Z�����
    //���S���甼�ar���ꂽ�~����̃����_���Ȉʒu�����܂�܂�

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SpownEnemy()
    {
        var spawnPos = new Vector3(UnityEngine.Random.Range(-1.0f, 1.0f), UnityEngine.Random.Range(-1.0f, 1.0f), 0).normalized * MovementRange.movementRadius;

        Instantiate(enemyPrefab, spawnPos, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            // �N�[���^�C���̌v�Z
            currentTime += Time.deltaTime;
            if (currentTime >= spownDelay)
            {
                currentTime = 0;

                // ���̃N�[���^�C�����Z�b�g
                UnityEngine.Random.InitState(DateTime.Now.Millisecond);
                spownDelay = UnityEngine.Random.Range(spownDelayMin, spownDelayMax);

                // �����_������
                SpownEnemy();
            }
        }
    }
}
