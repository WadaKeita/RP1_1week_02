using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundTarget : MonoBehaviour
{
    private GameObject targetObject;

    private Vector3 RotateAxis = Vector3.forward;

    private float SpeedFactor = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");

        targetObject = player;

    }

    // Update is called once per frame
    void Update()
    {

        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == false)
        {
            if (targetObject == null) return;

            if (Input.GetKey(KeyCode.Joystick1Button4))
            {
                // 指定オブジェクトを中心に回転する
                this.transform.RotateAround(
                    targetObject.transform.position,
                    RotateAxis,
                    360.0f / (1.0f / SpeedFactor) * Time.deltaTime);

                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);
            }
            if (Input.GetKey(KeyCode.Joystick1Button5))
            {
                // 指定オブジェクトを中心に回転する
                this.transform.RotateAround(
                    targetObject.transform.position,
                    RotateAxis,
                    -(360.0f / (1.0f / SpeedFactor) * Time.deltaTime));

                this.transform.rotation = Quaternion.Euler(0.0f, 0.0f, 0.0f);

            }
            else
            {
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }
        }
    }
}