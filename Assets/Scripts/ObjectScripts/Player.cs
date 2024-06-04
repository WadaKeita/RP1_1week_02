using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class Player : MonoBehaviour
{
    public static GameObject player;
    public GameObject AttackOxygenPrefab;

    #region var-Player
    [Header("ƒvƒŒƒCƒ„[")]
    [SerializeField] public float moveSpeed = 5.0f;  // ˆÚ“®‘¬“x
    [SerializeField] public Vector3 startPos = new Vector3(2, 2, 0);  // ‰ŠúˆÊ’u
    [SerializeField] public float shotPower = 3.0f; // _‘f‚ğ•ú‚Â‹­‚³
    [SerializeField] public float downPower = 0.9f; // •t‚¯‚½_‘f‚Ì”*n”{
    #endregion

    bool Rtrigger = false;

    //public GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<GameObject>();
        player.transform.position = startPos;
        //gameManager = GameManager.gameManager;
    }
    private void OxygenShot(float power)
    {
        GameObject objTmp = OxygenManager.OxygenList[OxygenManager.OxygenList.Count - 1];
        OxygenManager.OxygenList.Remove(objTmp);
        // UŒ‚_‘f‚ÌƒNƒ[ƒ“‚ğì¬
        GameObject clone = Instantiate(AttackOxygenPrefab, objTmp.transform.position, Quaternion.identity);
        Destroy(objTmp);

        Vector3 direction = Vector3.zero;
        if (clone.transform.position != this.transform.position)
        {
            direction = clone.transform.position - this.transform.position;
            direction = direction.normalized;
        }
        clone.GetComponent<Rigidbody2D>().velocity = direction * power;

        //// •ú‚Á‚½_‘f‚ÌinterlockƒXƒNƒŠƒvƒg‚ğOff‚É‚·‚é
        //var interlock = objTmp.GetComponent<InterlockPlayer>();
        //interlock.enabled = false;
    }

    // _‘f‚ğ‘S•”è•ú‚·
    private void OxygenLetgo()
    {

        for (int i = OxygenManager.OxygenList.Count; i > 0; i--)
        {
            GameObject oxy = OxygenManager.OxygenList[i - 1];

            // —£‚ê‚½_‘f‚ğ’Êí_‘f‚É‚·‚é
            GameObject clone = Instantiate(AttackOxygenPrefab, oxy.gameObject.transform.position, Quaternion.identity);

            OxygenManager.OxygenList.Remove(oxy.gameObject);

            Vector3 direction = Vector3.zero;
            if (clone.transform.position != player.transform.position)
            {
                direction = clone.transform.position - player.transform.position;
                direction = direction.normalized;
            }
            clone.gameObject.GetComponent<Rigidbody2D>().velocity = direction * 2;

            // Œq‚ª‚Á‚Ä‚¢‚é_‘f‚ğíœ
            Destroy(oxy.gameObject);
            Debug.Log("SKUJO!!!!");

        }
    }

    private void PlayerMove()
    {
        // ---------- ˆÚ“® ----------
        Vector3 moveVelocity = Vector3.zero;

        // --- ƒXƒeƒBƒbƒN‘€ì ---
        if (Input.GetAxis("L_Stick_H") != 0 || Input.GetAxis("L_Stick_V") != 0)
        {
            // ¶‰EˆÚ“®
            moveVelocity.x += moveSpeed * Input.GetAxis("L_Stick_H");

            // ã‰ºˆÚ“®
            moveVelocity.y += moveSpeed * Input.GetAxis("L_Stick_V");
        }

        float connectNum = OxygenManager.OxygenList.Count;
        GetComponent<Rigidbody2D>().velocity = moveVelocity * Mathf.Pow(0.9f, connectNum);

        Vector3 posDif = (this.gameObject.transform.position + moveVelocity) - this.gameObject.transform.position;
        float angle = Mathf.Atan2(posDif.y, posDif.x) * Mathf.Rad2Deg;
        Vector3 euler = new Vector3(0, 0, angle);

        this.gameObject.transform.rotation = Quaternion.Euler(euler);

        //Vector2 lookDir = moveVelocity - this.transform.position;
        ////‚»‚µ‚Ä‚±‚ê‚Å‚Ç‚¤‚â‚Á‚Ä‚â‚é‚Ì‚©‚Æ‚¢‚¤‚ÆAMatf.Atan2‚Æ‚¢‚¤ŠÖ”‚Å‹——£‚ğg‚Á‚ÄŠp“x‚ğ‹‚ß‚ç‚ê‚Ü‚·B

        //float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        //this.gameObject.transform.rotation = new Vector3(angle,0,0);
    }

    // Update is called once per frame
    void Update()
    {

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            PlayerMove();

            if (Input.GetKeyDown(KeyCode.JoystickButton5))
            {
                if (OxygenManager.OxygenList.Count >= 1)
                {
                    OxygenShot(shotPower);
                }
            }
            if (Input.GetKeyDown(KeyCode.JoystickButton2))
            {
                if (OxygenManager.OxygenList.Count >= 1)
                {
                    OxygenLetgo();
                }
            }
            else if (Input.GetAxis("L_R_Trigger") > 0 && Rtrigger == false)
            {
                Rtrigger = true;
                if (OxygenManager.OxygenList.Count >= 1)
                {
                    OxygenShot(shotPower);
                }
            }
            if (Input.GetAxis("L_R_Trigger") == 0 && Rtrigger == true)
            {
                Rtrigger = false;
            }

            // ƒvƒŒƒCƒ„[‚Ìƒ|ƒWƒVƒ‡ƒ“‚ğmovementRange‚Ì’†‚Éû‚ß‚é
            Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

            if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(-tmp.x, GetComponent<Rigidbody2D>().velocity.y); }
            if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -tmp.y); }

            transform.position = tmp;
        }
        else
        {
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
    }
}
