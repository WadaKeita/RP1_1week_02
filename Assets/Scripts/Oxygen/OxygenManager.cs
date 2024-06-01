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
    public static Stack<GameObject> OxygenStack = new Stack<GameObject>();


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
