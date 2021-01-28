using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.Audio;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;

    [SerializeField] private Slider healthBar;
    [SerializeField] private TMP_Text toolboxCounterTxt;
    [SerializeField] private GameObject pauseMenuPanel;
    [SerializeField] private GameObject gameOverPanel;

    [SerializeField] private AudioSource appleInteractSound;
    [SerializeField] private AudioSource toolboxInteractSound;

    private string preToolBoxCounterTxt = "Toolboxes Collected: ";
    private string postToolBoxCounterTxt = "/6";

    private int toolboxesCollected = 0;
    private static float health;
    private static float healthLossOverTime = 0.6f; // Easy difficulty adjustment can be made here 

    void Awake()
    {
        if (instance == null)
        {
            instance = this; 
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        health = 100; // Health will always stay the same for slider health bar, difficulty will be adjusted via healthLossOverTime 
        toolboxCounterTxt.text = preToolBoxCounterTxt + toolboxesCollected.ToString() + postToolBoxCounterTxt;
        pauseMenuPanel.gameObject.SetActive(false);
        gameOverPanel.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        health -= healthLossOverTime * Time.deltaTime;
        healthBar.value = health; 
        toolboxCounterTxt.text = preToolBoxCounterTxt + toolboxesCollected.ToString() + postToolBoxCounterTxt;
        togglePauseMenu();
        GameOver(); // Game Over is here, but Game Win is located in Antenna Interact script
    }

    public void EatApple()
    {
        appleInteractSound.Play();
        if (health <= 95)
        {
            health += 5;
        }
        else if (health >= 96)
        {
            health += (100 - health);
        }
    }

    public void CollectToolbox()
    {
        toolboxInteractSound.Play();
        toolboxesCollected += 1;
    }

    public bool AllToolboxesCollected()
    {
        if (toolboxesCollected == 6)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    private void GameOver()
    {
        if (health <= 0)
        {
            gameOverPanel.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
    }

    private void togglePauseMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            pauseMenuPanel.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        // Trouble adding an option for user to press escape again and close the pause menu
    }
}
