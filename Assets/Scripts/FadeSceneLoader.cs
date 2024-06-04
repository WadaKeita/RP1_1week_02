using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;             // �t�F�[�h�p��UI�p�l���iImage�j
    public AudioSource fadeSource;
    public float fadeDuration = 2.0f;   // �t�F�[�h�̊����ɂ����鎞��

    public AudioClip sound1;
    AudioSource audioSource;


    private void Start()
    {
        //fadeSceneLoader = this.gameObject;
        //StartCoroutine(FadeOutAndLoadScene());
        //Component���擾
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // �p�l����L����
        fadeSource.enabled = true;
        float elapsedTime = 0.0f;                 // �o�ߎ��Ԃ�������
        Color startColor = fadePanel.color;       // �t�F�[�h�p�l���̊J�n�F���擾
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // �t�F�[�h�p�l���̍ŏI�F��ݒ�

        // �t�F�[�h�A�E�g�A�j���[�V���������s
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // �o�ߎ��Ԃ𑝂₷
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // �t�F�[�h�̐i�s�x���v�Z
            fadePanel.color = Color.Lerp(startColor, endColor, t); // �p�l���̐F��ύX���ăt�F�[�h�A�E�g
            yield return null;                                     // 1�t���[���ҋ@
        }

        fadePanel.color = endColor;  // �t�F�[�h������������ŏI�F�ɐݒ�
        SceneManager.LoadScene("ResultScene"); // �V�[�������[�h���ă��j���[�V�[���ɑJ��
    }

    private void Update()
    {
        GameObject gameManager = GameManager.gameManager;
        if (gameManager.GetComponent<GameManager>().GetIsEnd() == true)
        {
            //audioSource.PlayOneShot(sound1);
            StartCoroutine(FadeOutAndLoadScene());
        }
    }
}

