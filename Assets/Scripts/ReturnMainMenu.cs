using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnMainMenu : MonoBehaviour
{
    public AsyncOperation async; 

    public void BtnMainMenu()
    {
        if (async == null)
        {
            // Do not need to free cursor here, already has been unlocked via opening the pause menu
            Scene currScene = SceneManager.GetActiveScene();
            async = SceneManager.LoadSceneAsync(currScene.buildIndex - 2);
            async.allowSceneActivation = true;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
