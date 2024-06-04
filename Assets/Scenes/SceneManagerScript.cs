using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemanagerScript : MonoBehaviour
{
    public string currentScene;
    public string titleSceneName;
    public string gameSceneName;
    public string resultSceneName;

    // Start is called before the first frame update
    void Start()
    {
        titleSceneName = "TitleScene";
        gameSceneName = "SampleScene";
        resultSceneName = "ResultScene";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == titleSceneName)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene(gameSceneName);
            }
        }
        if(currentScene == gameSceneName)
        {
            GameObject gameManager = GameManager.gameManager;
            if (gameManager.GetComponent<GameManager>().GetIsEnd() == true)
            {
                if (Input.GetKeyDown(KeyCode.JoystickButton0))
                {
                    SceneManager.LoadScene(resultSceneName);
                }
            }
        }
        if (currentScene == resultSceneName)
        {
            if (Input.GetKeyDown(KeyCode.JoystickButton0))
            {
                SceneManager.LoadScene(titleSceneName);
            }
        }
    }
}
