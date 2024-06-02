using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    [Header("é_ëf")]
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

        //    // ìñÇΩÇ¡ÇΩé_ëfÇÃinterlockÉXÉNÉäÉvÉgÇOnÇ…Ç∑ÇÈ
        //    var interlock = collision.GetComponent<InterlockPlayer>();
        //    interlock.enabled = true;
        //    //interlock.GetComponent<InterlockPlayer>().PosSet();


        //    // à íuÇÃÇ∏ÇÍÇèCê≥Ç∑ÇÈÅAé_ëfÇ…Ç“Ç¡ÇΩÇËí£ÇËïtÇ≠ÇÊÇ§Ç…
        //    Vector3 direction = Vector3.zero;
        //    if (collision.gameObject.transform.position != this.transform.position)
        //    {
        //        direction = collision.gameObject.transform.position - this.transform.position;
        //        direction = direction.normalized;
        //    }
        //    Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    collision.gameObject.transform.position = this.transform.position + Vector3.Scale(direction, kyori);

        //    // é_ëfÇÃèÓïÒÇÉXÉ^ÉbÉNÇ∑ÇÈ
        //    OxygenManager.OxygenStack.Push(collision.gameObject);

        //    Debug.Log("ê⁄êG");
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
        //    // ÉvÉåÉCÉÑÅ[Ç…ïtÇ¢ÇƒÇ¢ÇÈé_ëfÇçÏê¨
        //    GameObject clone = Instantiate(connectOxygenPrefab, this.gameObject.transform.position, Quaternion.identity);
        //    // é_ëfÇçÌèú
        //    Destroy(this.gameObject);

        //    // é_ëfÇÃèÓïÒÇÉXÉ^ÉbÉNÇ∑ÇÈ
        //    OxygenManager.OxygenList.Add(clone.gameObject);
        //}

        //if (collision.gameObject.tag == ("Player") && isConnect == false)
        //{
        //    isConnect = true;
        //    Debug.Log("ïtÇ¢ÇΩ?");

        //    //// à íuÇÃÇ∏ÇÍÇèCê≥Ç∑ÇÈÅAÉvÉåÉCÉÑÅ[Ç…Ç“Ç¡ÇΩÇËí£ÇËïtÇ≠ÇÊÇ§Ç…
        //    //Vector3 direction = Vector3.zero;
        //    //if (collision.gameObject.transform.position != this.transform.position)
        //    //{
        //    //    direction = this.transform.position - collision.gameObject.transform.position;
        //    //    direction = direction.normalized;
        //    //}
        //    //Vector3 kyori = (collision.gameObject.transform.localScale / 2) + (this.transform.localScale / 2);
        //    //this.transform.position = collision.gameObject.transform.position + Vector3.Scale(direction, kyori);

        //    // ÉvÉåÉCÉÑÅ[Ç…ïtÇ¢ÇƒÇ¢ÇÈé_ëfÇçÏê¨
        //    GameObject clone = Instantiate(connectOxygenPrefab, this.transform.position, Quaternion.identity);
        //    // é_ëfÇçÌèú
        //    Destroy(this.gameObject);

        //    // é_ëfÇÃèÓïÒÇÉXÉ^ÉbÉNÇ∑ÇÈ
        //    OxygenManager.OxygenList.Add(clone.gameObject);

        //}
        //rb.velocity = Vector3.zero;
    }
}
