using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject movementRangePrefab;
    public GameObject blackHolePrefab;
    public GameObject blackHoleChargePrefab;

    public bool isEnd = false;

    public static GameObject gameManager;

    // Start is called before the first frame update
    void Start()
    {
        //player.transform.position = new Vector3(0, 0, 0);
        // �v���C���[�̐���
        Player.player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // �s���͈͂̐���
        MovementRange.movementRange = Instantiate(movementRangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        // �u���b�N�z�[���̐���
        BlackHole.blackHole = Instantiate(blackHolePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        BlackHoleCharge.blackHoleCharge = Instantiate(blackHoleChargePrefab, new Vector3(0, 0, 0), Quaternion.identity);

        gameManager = this.gameObject;
    }

    public void SetIsEnd(bool clear) { isEnd = clear; }
    public bool GetIsEnd() { return isEnd; }

    // Update is called once per frame
    void Update()
    {
        //if(isEnd)
        //{
        //    GameObject obj = FadeSceneLoader.fadeSceneLoader;
        //    StartCoroutine(obj.GetComponent<FadeSceneLoader>().FadeOutAndLoadScene());
        //}
        // �v���C���[�̑��x���Q�[���}�l�[�W���[�ő���ł��邩�e�X�g
        // player.GetComponent<Rigidbody2D>().velocity = Vector3.left;
    }
}
