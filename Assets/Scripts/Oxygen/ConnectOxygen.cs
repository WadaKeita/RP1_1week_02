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

            // 位置のずれを修正する、プレイヤーにぴったり張り付くように
            Vector3 direction = Vector3.zero;
            if (collision.gameObject.transform.position != this.transform.position)
            {
                direction = collision.gameObject.transform.position - this.transform.position;
                direction = direction.normalized;
            }
            Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
            collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

            // プレイヤーに付いている酸素を作成
            GameObject clone = Instantiate(connectOxygenPrefab, collision.gameObject.transform.position, Quaternion.identity);
            // 酸素を削除
            Destroy(collision.gameObject);

            // 酸素の情報をスタックする
            OxygenManager.OxygenStack.Push(clone.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
