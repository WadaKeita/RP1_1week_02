using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // ‚±‚ÌƒXƒNƒŠƒvƒg‚Å_‘f‚ÌoŒ»‚ğŠÇ—‚·‚é

    public GameObject oxygenPrefab;
    public GameObject connectOxygenPrefab;
    public GameObject attackOxygenPrefab;

    public GameObject player;

    #region var-Oxygen
    [Header("_‘fŠÇ—")]
    public int maxNumber = 10;  // _‘f‚ÌÅ‘å”
    public static int currentNumber = 0;  // Œ»İ‚ÌŒÂ”
    #endregion

    // ‚­‚Á‚Â‚¢‚½_‘f‚Ìî•ñ‚ğƒŠƒXƒg‚É“ü‚ê‚é
    public static List<GameObject> OxygenList = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void LateUpdate()
    {

        GameObject[] oxygens = null;
        if (oxygens == null)
        {
            oxygens = GameObject.FindGameObjectsWithTag("Oxygen");
        }
        foreach (GameObject oxygen in oxygens)
        {
            float distance = Vector2.Distance(player.transform.position, oxygen.transform.position);
            float radius = (player.transform.localScale.x / 2) + (oxygen.transform.localScale.x / 2);

            if (distance <= radius)
            {
                if (oxygen != null && oxygen.GetComponent<Oxygen>().GetIsConnect() == false)
                {
                    // ƒvƒŒƒCƒ„[‚É•t‚¢‚Ä‚¢‚é_‘f‚ğì¬
                    GameObject clone = Instantiate(connectOxygenPrefab, oxygen.gameObject.transform.position, Quaternion.identity);

                    oxygen.GetComponent<Oxygen>().SetIsConnect(true);

                    // _‘f‚ğíœ
                    Destroy(oxygen.gameObject);

                    // _‘f‚Ìî•ñ‚ğƒXƒ^ƒbƒN‚·‚é
                    OxygenList.Add(clone.gameObject);

                    Debug.Log("‚±‚±‚Å‘‚¦‚½‚ñ‚æ‡@");
                }
            }
        }

        GameObject[] connects = null;
        if (connects == null)
        {
            connects = GameObject.FindGameObjectsWithTag("ConnectOxygen");
        }
        foreach (GameObject connect in connects)
        {
            GameObject[] oxys = null;
            if (oxys == null)
            {
                oxys = GameObject.FindGameObjectsWithTag("Oxygen");
            }
            foreach (GameObject oxy in oxys)
            {
                float distance;
                distance = Vector2.Distance(connect.transform.position, oxy.gameObject.transform.position);
                float radius = (connect.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);

                if (distance <= radius)
                {
                    if (oxy != null && oxy.GetComponent<Oxygen>().GetIsConnect() == false)
                    {
                        // ƒvƒŒƒCƒ„[‚É•t‚¢‚Ä‚¢‚é_‘f‚ğì¬
                        GameObject clone = Instantiate(connectOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                        oxy.GetComponent<Oxygen>().SetIsConnect(true);

                        // _‘f‚ğíœ
                        Destroy(oxy.gameObject);

                        // _‘f‚Ìî•ñ‚ğƒXƒ^ƒbƒN‚·‚é
                        OxygenList.Add(clone.gameObject);
                        Debug.Log("‚±‚±‚Å‘‚¦‚½‚ñ‚æ‡A");
                    }
                }
            }
        }

        // Œq‚ª‚Á‚Ä‚é_‘f‚½‚¿‚Ì”»’è‚ğ‹‚ß‚é
        if (OxygenList.Count > 0)
        {

            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);
            }
            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];

                // ƒvƒŒƒCƒ„[‚Æ‚Ô‚Â‚©‚Á‚Ä‚¢‚½‚çƒvƒŒƒCƒ„[ƒRƒlƒNƒg‚ğtrue‚É‚·‚é
                float distance = Vector2.Distance(player.transform.position, oxy.transform.position);
                float radius = (player.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }

                for (int j = 0; j < OxygenList.Count; j++)
                {
                    GameObject oxygen = OxygenList[j];

                    if (oxy != oxygen)
                    {
                        distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                        radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                        if (distance <= radius)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                            {
                                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                Debug.Log(oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect());
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {

                GameObject oxy = OxygenList[i];
                if (!oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect())
                {
                    // —£‚ê‚½_‘f‚ğ’Êí_‘f‚É‚·‚é
                    GameObject clone = Instantiate(attackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenList.Remove(oxy.gameObject);

                    Vector3 direction = Vector3.zero;
                    if (clone.transform.position != player.transform.position)
                    {
                        direction = clone.transform.position - player.transform.position;
                        direction = direction.normalized;
                    }
                    clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;

                    // Œq‚ª‚Á‚Ä‚¢‚é_‘f‚ğíœ
                    Destroy(oxy.gameObject);
                }
            }
        }
    }
}
