using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectOxygen : MonoBehaviour
{
    public GameObject scoreManager;

    public bool isPlayerConnect;
    //public bool isOxygenConnect;

    // Start is called before the first frame update
    void Start()
    {
        scoreManager = ScoreManager.scoreManager;
        isPlayerConnect = false;
        //isOxygenConnect = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == ("BlackHole"))
        {
            isPlayerConnect = false;

            scoreManager.GetComponent<ScoreManager>().ScoreUP();

            OxygenManager.OxygenList.Remove(this.gameObject);
            // é©ï™ÇçÌèú
            Destroy(this.gameObject);
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "ConnectOxygen")
        {
            Debug.Log("ó£ÇÍÇΩÅI");
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
            Debug.Log("Ç¬Ç»Ç™ÇËÇä¥Ç∂ÇÈ");
        }
    }
}
