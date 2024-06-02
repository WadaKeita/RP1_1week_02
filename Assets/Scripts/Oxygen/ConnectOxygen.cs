using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public GameObject connectOxygenPrefab;
    public GameObject oxygenPrefab;
    public GameObject gameManager;

    public bool isPlayerConnect;
    //public bool isOxygenConnect;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.gameManager;
        isPlayerConnect = false;
        //isOxygenConnect = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("BlackHole"))
        {
            isPlayerConnect = false;

            gameManager.GetComponent<GameManager>().ScoreUP();

            OxygenManager.OxygenList.Remove(this.gameObject);
            // ©•ª‚ğíœ
            Destroy(this.gameObject);
        }

        //isPlayerConnect = false;
        //if (collision.gameObject.tag == ("Player"))
        //{
        //    isPlayerConnect = true;
        //}
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //// ƒuƒ‰ƒbƒNƒz[ƒ‹‚É“–‚½‚Á‚½‚çƒXƒRƒA‚É‚È‚é
        //if (collision.gameObject.tag == ("BlackHole"))
        //{
        //    isPlayerConnect = false;

        //    gameManager.GetComponent<GameManager>().ScoreUP();

        //    OxygenManager.OxygenList.Remove(this.gameObject);
        //    // ©•ª‚ğíœ
        //    Destroy(this.gameObject);
        //}


    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectOxygen")
        {
            Debug.Log("—£‚ê‚½I");
        }
    }

    public bool GetIsPlayerConnect()
    {
        return isPlayerConnect;
    }
    public void SetIsPlayerConnect(bool isConnect)
    {
        isPlayerConnect = isConnect;
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlayerConnect)
        {
            Debug.Log("‚Â‚È‚ª‚è‚ğŠ´‚¶‚é");
        }

        //GameObject[] oxygens = null;
        //if (oxygens == null)
        //{
        //    oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        //}
        //foreach (GameObject oxygen in oxygens)
        //{
        //    float distance;
        //    distance = Vector2.Distance(oxygen.transform.position, this.gameObject.transform.position);
        //    float radius = (this.gameObject.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

        //    if (distance <= radius)
        //    {
        //        // ƒvƒŒƒCƒ„[‚É•t‚¢‚Ä‚¢‚é_‘f‚ğì¬
        //        GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);
        //        // _‘f‚ğíœ
        //        Destroy(oxygen.gameObject);

        //        // _‘f‚Ìî•ñ‚ğƒXƒ^ƒbƒN‚·‚é
        //        OxygenManager.OxygenList.Add(clone.gameObject);
        //    }
        //}

        //// _‘f‚É“–‚½‚Á‚½‚ç“–‚½‚Á‚½_‘f‚ªŒq‚ª‚é
        //if (collision.gameObject.tag == ("Oxygen") && collision.GetComponent<Oxygen>().GetIsConnect() == false)
        //{
        //    collision.GetComponent<Oxygen>().SetIsConnect(true);

        //    //// ˆÊ’u‚Ì‚¸‚ê‚ğC³‚·‚éAƒvƒŒƒCƒ„[‚É‚Ò‚Á‚½‚è’£‚è•t‚­‚æ‚¤‚É
        //    //Vector3 direction = Vector3.zero;
        //    //if (collision.gameObject.transform.position != this.transform.position)
        //    //{
        //    //    direction = collision.gameObject.transform.position - this.transform.position;
        //    //    direction = direction.normalized;
        //    //}
        //    //Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    //collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //}

        //if (isPlayerConnect == false)
        //{
        //    // —£‚ê‚½_‘f‚ğ’Êí_‘f‚É‚·‚é
        //    GameObject clone = Instantiate(oxygenPrefab, this.gameObject.transform.position, Quaternion.identity);

        //    OxygenManager.OxygenList.Remove(this.gameObject);

        //    // Œq‚ª‚Á‚Ä‚¢‚é_‘f‚ğíœ
        //    Destroy(this.gameObject);
        //}
    }
}
