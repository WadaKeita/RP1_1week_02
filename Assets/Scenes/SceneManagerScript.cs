using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenemanagerScript : MonoBehaviour
{
    public string currentScene;
    public string titleSceneName;
    public string gameSceneName;

    // Start is called before the first frame update
    void Start()
    {
        titleSceneName = "TitleScene";
        gameSceneName = "SampleScene";
    }

    // Update is called once per frame
    void Update()
    {
        if (currentScene == titleSceneName)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SceneManager.LoadScene(gameSceneName);
                currentScene = gameSceneName;
            }
        }
        if(currentScene == gameSceneName)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                SceneManager.LoadScene(gameSceneName);
                currentScene = titleSceneName;
            }
        }
    }
}
