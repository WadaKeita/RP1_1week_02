using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class FadeSceneLoader : MonoBehaviour
{
    public Image fadePanel;             // フェード用のUIパネル（Image）
    public AudioSource fadeSource;
    public float fadeDuration = 2.0f;   // フェードの完了にかかる時間

    public AudioClip sound1;
    AudioSource audioSource;


    private void Start()
    {
        //fadeSceneLoader = this.gameObject;
        //StartCoroutine(FadeOutAndLoadScene());
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    public IEnumerator FadeOutAndLoadScene()
    {
        fadePanel.enabled = true;                 // パネルを有効化
        fadeSource.enabled = true;
        float elapsedTime = 0.0f;                 // 経過時間を初期化
        Color startColor = fadePanel.color;       // フェードパネルの開始色を取得
        Color endColor = new Color(startColor.r, startColor.g, startColor.b, 1.0f); // フェードパネルの最終色を設定

        // フェードアウトアニメーションを実行
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;                        // 経過時間を増やす
            float t = Mathf.Clamp01(elapsedTime / fadeDuration);  // フェードの進行度を計算
            fadePanel.color = Color.Lerp(startColor, endColor, t); // パネルの色を変更してフェードアウト
            yield return null;                                     // 1フレーム待機
        }

        fadePanel.color = endColor;  // フェードが完了したら最終色に設定
        SceneManager.LoadScene("ResultScene"); // シーンをロードしてメニューシーンに遷移
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

