using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : MonoBehaviour
{

    #region var-BlackHole
    [Header("�u���b�N�z�[��")]
    [SerializeField] public float chargePercentage; // n%
    [SerializeField] public float chargeIncrease; // �`���[�W�����ʁi�_�f1�j
    [SerializeField] public float chargeDecrease; // �`���[�W�����ʁi�b��n�p�[�Z���g�j
    #endregion

    public static GameObject blackHole;

    public float GetChargePercentage()
    {
        return chargePercentage;
    }

    // Start is called before the first frame update
    void Start()
    {
        blackHole = this.gameObject;
    }

    public void ChargePercentageUP() 
    { 
        chargePercentage += chargeIncrease;
        if(chargePercentage >= 100)
        {
            GameObject obj = TimeManager.timeManager;
            obj.GetComponent<TimeManager>().TimeIncrease();
            chargePercentage = 0;
        }
    }

    // Update is called once per frame
    void Update()
    {
        chargePercentage -= chargeDecrease * Time.deltaTime;
        if (chargePercentage < 0) { chargePercentage = 0; }
    }
}
