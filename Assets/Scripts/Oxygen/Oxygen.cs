using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Oxygen : MonoBehaviour
{

    public bool isConnect = false;
    #region var-Oxygen
    //[Header("Ž_‘f")]
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        isConnect = false;
    }

    public bool GetIsConnect() { return isConnect; }
    public void SetIsConnect(bool connect) { isConnect = connect; }


    // Update is called once per frame
    void Update()
    {

    }
}
