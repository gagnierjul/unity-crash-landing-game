using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    public AsyncOperation async;

    public void Restart()
    {
        Scene currScene = SceneManager.GetActiveScene();
        async = SceneManager.LoadSceneAsync(currScene.buildIndex - 1);
        async.allowSceneActivation = true;
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
