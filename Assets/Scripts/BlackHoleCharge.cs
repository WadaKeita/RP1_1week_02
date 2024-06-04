using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BlackHoleCharge : MonoBehaviour
{
    public static GameObject blackHoleCharge;

    // Start is called before the first frame update
    void Start()
    {
        blackHoleCharge = this.gameObject;
        GameObject obj = BlackHole.blackHole;
        gameObject.transform.position = new Vector3(0, (obj.transform.localScale.y / 2) + 0.5f, 0);
        gameObject.transform.localScale = new Vector3(0, 0.25f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        // Color(0.42352941176471f ,0.85490196078431f ,0.12156862745098f);  // �X�^�[�g�J���[
        // Color(0.81176470588235f ,0.16862745098039f ,0.16862745098039f);  // �S�[���J���[

        GameObject obj = BlackHole.blackHole;
        // �O���f�[�V�����̃|�W�V�������Ǘ�����l 0f~1f
        float currentPointColor = (float)obj.GetComponent<BlackHole>().GetChargePercentage() / (float)100;
        if (currentPointColor > 1)
        {
            currentPointColor = 1;
        }

        float r = (0.81f - 0.42f) * currentPointColor + 0.42f; // �w��̐F����w��F�փO���f�[�V����
        float g = (0.16f - 0.85f) * currentPointColor + 0.85f; // �w��̐F����w��F�փO���f�[�V����
        float b = (0.16f - 0.12f) * currentPointColor + 0.12f; // �w��̐F����w��F�փO���f�[�V����


        gameObject.GetComponent<Renderer>().material.color = new Color(r, g, b);

        gameObject.transform.localScale = new Vector3(currentPointColor * 2, 0.25f, 0);
    }
}
