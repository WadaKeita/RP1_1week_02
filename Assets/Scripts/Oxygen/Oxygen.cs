using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    [Header("�_�f")]
    #endregion

    public GameObject connectOxygenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        isConnect = false;
    }

    public bool GetIsConnect() { return isConnect; }
    public void SetIsConnect(bool connect) { isConnect = connect; }

    private void OnTriggerEnter2D(Collider2D collision)
    {


        //if (collision.gameObject.tag == ("Oxygen") &&
        //    collision.gameObject.GetComponent<Oxygen>().isConnect == false)
        //{
        //    collision.GetComponent<Oxygen>().isConnect = true;

        //    // ���������_�f��interlock�X�N���v�g��On�ɂ���
        //    var interlock = collision.GetComponent<InterlockPlayer>();
        //    interlock.enabled = true;
        //    //interlock.GetComponent<InterlockPlayer>().PosSet();


        //    // �ʒu�̂�����C������A�_�f�ɂ҂����蒣��t���悤��
        //    Vector3 direction = Vector3.zero;
        //    if (collision.gameObject.transform.position != this.transform.position)
        //    {
        //        direction = collision.gameObject.transform.position - this.transform.position;
        //        direction = direction.normalized;
        //    }
        //    Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //    // �_�f�̏����X�^�b�N����
        //    OxygenManager.OxygenStack.Push(collision.gameObject);

        //    Debug.Log("�ڐG");
        //    Debug.Log(OxygenManager.OxygenStack.Count);
        //}

    }

    // Update is called once per frame
    void LateUpdate()
    {

        //GameObject player = GameObject.FindGameObjectWithTag("Player");

        //float distance;
        //distance = Vector2.Distance(player.transform.position, this.gameObject.transform.position);
        //float radius = (this.gameObject.transform.localScale.x / 2) + (player.transform.localScale.x / 2);

        //if (distance <= radius)
        //{
        //    // �v���C���[�ɕt���Ă���_�f���쐬
        //    GameObject clone = Instantiate(connectOxygenPrefab, this.gameObject.transform.position, Quaternion.identity);
        //    // �_�f���폜
        //    Destroy(this.gameObject);

        //    // �_�f�̏����X�^�b�N����
        //    OxygenManager.OxygenList.Add(clone.gameObject);
        //}

        //if (collision.gameObject.tag == ("Player") && isConnect == false)
        //{
        //    isConnect = true;
        //    Debug.Log("�t����?");

        //    //// �ʒu�̂�����C������A�v���C���[�ɂ҂����蒣��t���悤��
        //    //Vector3 direction = Vector3.zero;
        //    //if (collision.gameObject.transform.position != this.transform.position)
        //    //{
        //    //    direction = this.transform.position - collision.gameObject.transform.position;
        //    //    direction = direction.normalized;
        //    //}
        //    //Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    //this.transform.position = collision.gameObject.transform.position + Vector3.Scale(direction, kyori);

        //    // �v���C���[�ɕt���Ă���_�f���쐬
        //    GameObject clone = Instantiate(connectOxygenPrefab, this.transform.position, Quaternion.identity);
        //    // �_�f���폜
        //    Destroy(this.gameObject);

        //    // �_�f�̏����X�^�b�N����
        //    OxygenManager.OxygenList.Add(clone.gameObject);

        //}
        //rb.velocity = Vector3.zero;
    }
}
