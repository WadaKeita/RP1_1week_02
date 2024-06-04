using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InterlockEnemy : MonoBehaviour
{
    GameObject enemy;

    private Vector3 prePosition;

    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetEnemy(GameObject obj)
    {
        enemy = obj;
        prePosition = enemy.transform.position;
    }

    // Update is called once per frame
    public void Update()
    {
        if (enemy != null)
        {
            if (enemy.transform.position != prePosition)
            {
                this.transform.position += enemy.transform.position - prePosition;

                prePosition = enemy.transform.position;
            }
        }
    }
}
