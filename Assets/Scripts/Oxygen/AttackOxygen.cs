using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AttackOxygen : MonoBehaviour
{
    public GameObject oxygenPrefab;
    public GameObject attackRB;

    public float stopSpeed = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        //attackRB.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (GetComponent<Rigidbody2D>().velocity.x * GetComponent<Rigidbody2D>().velocity.x <= 0.1f &&
            GetComponent<Rigidbody2D>().velocity.y * GetComponent<Rigidbody2D>().velocity.y <= 0.1f)
        {
            // í èÌé_ëfÇÃÉNÉçÅ[ÉìÇçÏê¨
            GameObject clone = Instantiate(oxygenPrefab, this.transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }


        // çUåÇé_ëfÇÃÉ|ÉWÉVÉáÉìÇmovementRangeÇÃíÜÇ…é˚ÇﬂÇÈ
        Vector3 tmp = MovementRange.movementRange.GetComponent<MovementRange>().ClampCircle(transform.position);

        // í[Ç¡Ç±Ç‹Ç≈çsÇ¡ÇΩÇÁÇÕÇ∂Ç©ÇÍÇÈ
        //if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(-tmp.x, GetComponent<Rigidbody2D>().velocity.y); }
        //if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -tmp.y); }

        // í[Ç¡Ç±Ç‹Ç≈çsÇ¡ÇΩÇÁé~Ç‹ÇÈ
        if (transform.position.x != tmp.x) { GetComponent<Rigidbody2D>().velocity = new Vector2(0, GetComponent<Rigidbody2D>().velocity.y); }
        if (transform.position.y != tmp.y) { GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 0); }

        transform.position = tmp;
    }
}
