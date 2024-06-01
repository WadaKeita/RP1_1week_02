using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{
    Rigidbody2D rb;

    GameObject oxygen;

    public bool isConnect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        oxygen = GetComponent<GameObject>();
        isConnect = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isConnect == false)
        {
            if (collision.gameObject.tag == ("Player"))
            {
                isConnect = true;

                // ���g�̂�interlock�X�N���v�g��On�ɂ���
                var interlock = GetComponent<InterlockPlayer>();
                interlock.enabled = true;

                // �ʒu�̂�����C������A�v���C���[�ɂ҂����蒣��t���悤��
                Vector3 direction = Vector3.zero;
                if (collision.gameObject.transform.position != this.transform.position)
                {
                    direction = this.transform.position - collision.gameObject.transform.position;
                    direction = direction.normalized;
                }
                Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
                this.transform.position = collision.gameObject.transform.position + Vector3.Scale(direction, kyori);

                Debug.Log("�ڐG");
            }
        }
        else
        {
            if (collision.gameObject.tag == ("Oxygen"))
            {
                collision.GetComponent<Oxygen>().isConnect = true;

                // ���������_�f��interlock�X�N���v�g��On�ɂ���
                var interlock = collision.GetComponent<InterlockPlayer>();
                interlock.enabled = true;


                // �ʒu�̂�����C������A�_�f�ɂ҂����蒣��t���悤��
                Vector3 direction = Vector3.zero;
                if (collision.gameObject.transform.position != this.transform.position)
                {
                    direction = collision.gameObject.transform.position - this.transform.position;
                    direction = direction.normalized;
                }
                Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
                collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

                Debug.Log("�ڐG");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isConnect)
        {

        }
        //rb.velocity = Vector3.zero;
    }
}
