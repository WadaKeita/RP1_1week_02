using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyOxygen : MonoBehaviour
{
    public GameObject connectEnemy;
    public GameObject oxygenPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void SetConnect(GameObject enemy)
    {
        connectEnemy = enemy;
    }

    // Update is called once per frame
    void Update()
    {
        if(connectEnemy == null)
        {
            // é_ëfÇê∂ê¨
            GameObject clone = Instantiate(oxygenPrefab, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
