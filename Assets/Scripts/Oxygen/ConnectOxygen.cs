using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public GameObject connectOxygenPrefab;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.gameObject.tag == ("Oxygen") && collision.GetComponent<Oxygen>().GetIsConnect() == false)
        {
            collision.GetComponent<Oxygen>().SetIsConnect(true);

            // �ʒu�̂�����C������A�v���C���[�ɂ҂����蒣��t���悤��
            Vector3 direction = Vector3.zero;
            if (collision.gameObject.transform.position != this.transform.position)
            {
                direction = collision.gameObject.transform.position - this.transform.position;
                direction = direction.normalized;
            }
            Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
            collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

            // �v���C���[�ɕt���Ă���_�f���쐬
            GameObject clone = Instantiate(connectOxygenPrefab, collision.gameObject.transform.position, Quaternion.identity);
            // �_�f���폜
            Destroy(collision.gameObject);

            // �_�f�̏����X�^�b�N����
            OxygenManager.OxygenStack.Push(clone.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
