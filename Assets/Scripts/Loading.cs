using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Rendering;

// THIS SCRIPT HAS BEEN TAKEN FROM AN IN-CLASS ACTIVITY GIVEN BY MARC-ANDRE LAROUCHE (FALL 2019)
// IT HAS BEEN SLIGHTLY MODIFIED IN ORDER TO MEET THE NEEDS OF MY PROJECT

public class Loading : MonoBehaviour
{
    private AsyncOperation async; 

    [SerializeField] private Image progressBar;
    [SerializeField] private TMP_Text txtPercent;

    [SerializeField] private TMP_Text txtLoading;
    [SerializeField] private TMP_Text txtPressButton;

    [SerializeField] private bool waitForUserInput = false;
    private bool ready = false; 

    [SerializeField] private float delay = 0; 

    [SerializeField] private int sceneToLoad = -1; 

    // Start is called before the first frame update
    void Start()
    {
        txtPressButton.gameObject.SetActive(false);
        Time.timeScale = 1.0f;
        Input.ResetInputAxes(); 
        System.GC.Collect(); 

        Scene currentScene = SceneManager.GetActiveScene();
        if (sceneToLoad < 0)
        {
            async = SceneManager.LoadSceneAsync(currentScene.buildIndex + 1);
        }
        else
        {
            async = SceneManager.LoadSceneAsync(sceneToLoad);
        }
        async.allowSceneActivation = false; 
        if (waitForUserInput == false)
        {
            Invoke("Activate", delay);
        }
    }

    public void Activate()
    {
        ready = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (waitForUserInput && Input.anyKey)
        {
            ready = true;
        }
        if (progressBar)
        {
            progressBar.fillAmount = async.progress + 0.1f;
        }
        if (txtPercent)
        {
            txtPercent.text = ((async.progress + 0.1f) * 100).ToString("f2") + " %";
        }
        if(async.progress > 0.89f && SplashScreen.isFinished)
        {
            txtLoading.gameObject.SetActive(false);
            txtPressButton.gameObject.SetActive(true);
        }
        if (async.progress > 0.89f && SplashScreen.isFinished && ready)
        {
            async.allowSceneActivation = true;
        }
    }
}
