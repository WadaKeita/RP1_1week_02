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

                // 自身ののinterlockスクリプトをOnにする
                var interlock = GetComponent<InterlockPlayer>();
                interlock.enabled = true;

                // 位置のずれを修正する、プレイヤーにぴったり張り付くように
                Vector3 direction = Vector3.zero;
                if (collision.gameObject.transform.position != this.transform.position)
                {
                    direction = this.transform.position - collision.gameObject.transform.position;
                    direction = direction.normalized;
                }
                Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
                this.transform.position = collision.gameObject.transform.position + Vector3.Scale(direction, kyori);

                Debug.Log("接触");
            }
        }
        else
        {
            if (collision.gameObject.tag == ("Oxygen"))
            {
                collision.GetComponent<Oxygen>().isConnect = true;

                // 当たった酸素のinterlockスクリプトをOnにする
                var interlock = collision.GetComponent<InterlockPlayer>();
                interlock.enabled = true;


                // 位置のずれを修正する、酸素にぴったり張り付くように
                Vector3 direction = Vector3.zero;
                if (collision.gameObject.transform.position != this.transform.position)
                {
                    direction = collision.gameObject.transform.position - this.transform.position;
                    direction = direction.normalized;
                }
                Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
                collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

                Debug.Log("接触");
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
