using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenManager : MonoBehaviour
{
    // ‚±‚ÌƒXƒNƒŠƒvƒg‚Å_‘f‚ÌoŒ»‚ğŠÇ—‚·‚é

    public GameObject oxygenPrefab;

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

    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Œq‚ª‚Á‚Ä‚é_‘f‚½‚¿‚Ì”»’è‚ğ‹‚ß‚é
        if (OxygenList.Count > 0)
        {
            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(false);

                GameObject player = GameObject.FindGameObjectWithTag("Player");
                float distance;
                distance = Vector2.Distance(oxy.transform.position, player.gameObject.transform.position);
                float radius = (player.gameObject.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                if (distance <= radius)
                {
                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                }
            }



            for (int i = 0; i < OxygenList.Count; i++)
            {
                GameObject oxy = OxygenList[i];
                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {

                    for (int j = 0; j < OxygenList.Count; j++)
                    {
                        GameObject oxygen = OxygenList[j];

                        if (oxygen.gameObject != oxy.gameObject)
                        {
                            if (oxygen.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == true)
                            {
                                float distance = Vector2.Distance(oxy.transform.position, oxygen.transform.position);
                                float radius = (oxygen.transform.localScale.x / 2) + (oxy.transform.localScale.x / 2);
                                if (distance <= radius)
                                {
                                    oxy.GetComponent<ConnectOxygen>().SetIsPlayerConnect(true);
                                }
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < OxygenList.Count; i++)
            {
                //Debug.Log(OxygenList[i]);

                GameObject oxy = OxygenList[i];

                if (oxy.GetComponent<ConnectOxygen>().GetIsPlayerConnect() == false)
                {
                    // —£‚ê‚½_‘f‚ğ’Êí_‘f‚É‚·‚é
                    GameObject clone = Instantiate(oxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

                    OxygenManager.OxygenList.Remove(oxy.gameObject);

                    // Œq‚ª‚Á‚Ä‚¢‚é_‘f‚ğíœ
                    Destroy(oxy.gameObject);
                }
            }
        }
    }
}
