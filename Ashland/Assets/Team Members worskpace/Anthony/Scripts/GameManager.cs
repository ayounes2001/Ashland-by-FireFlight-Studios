using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public event Action pauseEvent;

    public event Action gameStartedEvent;

    public event Action gameOverEvent;
    public PlayerMovement player;
    
    private int nextSceneToLoad;
    
    // Start is called before the first frame update
    private void Singleton()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Awake()
    {
        Singleton();
    }
    void Start()
    {
        if (gameStartedEvent != null)
        {
            gameStartedEvent?.Invoke();
        }
    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
    

    public void GameOver()
    {
        player.GetComponent<HealthComponent>()?.Death();
        gameOverEvent?.Invoke();
    }
    public void SwitchScene()
    {

        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneToLoad);
       GetComponent<UIManager>().MainMenu?.SetActive(false);
    

    }
    public void GoBackToMainMenu()
    {
        nextSceneToLoad = SceneManager.GetActiveScene().buildIndex - 1;
        SceneManager.LoadScene(nextSceneToLoad);
        GetComponent<UIManager>().MainMenu?.SetActive(true);
        
    }
}
