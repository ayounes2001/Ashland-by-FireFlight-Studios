using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public static bool isPaused = false;

    public GameObject pauseMenuUI;
    public GameManager gameManager;

    public GameObject optionsUI;
    public Slider optionsSlider;
    public Text mouseSensText;

    public CamFollow camFollow;
    public GameObject MainMenu;
    
    
    



    public bool isKeyEnabled_ESC { get; set; }

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        pauseMenuUI?.SetActive(false);
        optionsUI?.SetActive(false);
        isKeyEnabled_ESC = true;

    }

    void Start()
    {
        gameManager.pauseEvent += Pause;
    }

// Update is called once per frame
    void Update()
    {
        if (isKeyEnabled_ESC)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (isPaused == true)
                {
                    Resume();

                }
                else
                {
                    Pause();

                }
            }
        }


    }

    public void OnChangeMouseSens(float sliderValue)
    {
        sliderValue = optionsSlider.value;
        sliderValue = camFollow.mouseSensitivity++;

        mouseSensText.text = sliderValue.ToString();

        optionsSlider.maxValue = 10;

    }

    public void Resume()
    {
        pauseMenuUI?.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
        isKeyEnabled_ESC = true;
    }

    void Pause()
    {
        pauseMenuUI?.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
        isKeyEnabled_ESC = true;


    }

    

   


    public void Settings()
    {
        pauseMenuUI?.SetActive(false);
        optionsUI?.SetActive(true);
        isPaused = false;
        isKeyEnabled_ESC = false;
    }
    
    //This will only work if we have only two scenes atm
    public void BackToMenu()
    {
        print("backtomenu");
        optionsUI.SetActive(false);
        int nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(nextSceneToLoad);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game");
        Application.Quit();
    }

   
    
}

