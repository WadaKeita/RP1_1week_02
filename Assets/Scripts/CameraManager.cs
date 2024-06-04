using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraManager : MonoBehaviour
{
    //Vector3 pos;              // �J�����̏����ʒu���L�����邽�߂̕ϐ�

    // Start is called before the first frame update
    void Start()
    {
        //pos = Camera.main.gameObject.transform.position; //�J�����̏����ʒu��ϐ�pos�ɓ����
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 cameraPos = Player.player.transform.position; // cameraPos�Ƃ����ϐ������A�Ǐ]����Ώۂ̈ʒu������
        cameraPos.z = -10; // �J�����̉��s���̈ʒu��-10������
        Camera.main.gameObject.transform.position = cameraPos; //�@�J�����̈ʒu�ɕϐ�cameraPos�̈ʒu������

        // �J�����̃|�W�V������movementRange�̒��Ɏ��߂�
        Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

        transform.position = tmp;
    }
}
