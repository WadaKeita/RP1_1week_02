using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject movementRangePrefab;

    public static GameObject gameManager;

    #region var-Score
    [Header("�X�R�A�Ǘ�")]
    [SerializeField] public float AcquisitionScore = 100;  // �l���X�R�A
    [SerializeField] public float currentScore = 0;  // ���݂̃X�R�A
    #endregion


    // Start is called before the first frame update
    void Start()
    {
        //player.transform.position = new Vector3(0, 0, 0);
        Player.player = Instantiate(playerPrefab, new Vector3(0, 0, 0), Quaternion.identity);
        MovementRange.movementRange = Instantiate(movementRangePrefab, new Vector3(0, 0, 0), Quaternion.identity);
        gameManager = this.gameObject;
    }

    public void ScoreUP()
    {
        currentScore += AcquisitionScore;
    }

    // Update is called once per frame
    void Update()
    {
        // �v���C���[�̑��x���Q�[���}�l�[�W���[�ő���ł��邩�e�X�g
        // player.GetComponent<Rigidbody2D>().velocity = Vector3.left;
    }
}
