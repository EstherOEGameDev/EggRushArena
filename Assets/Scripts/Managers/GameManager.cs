using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public enum GameState
    {
        Waiting, Playing,
        Won, Lost,
        Paused
    }

    public GameState state;


    public int score;
    
    public int targetScore=10;

    public float maxTime=60;

    float currentTime;

    bool gameEnded;

    void Awake()
    {
        if(Instance== null)
        {
            Instance= this;
        }

        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        StartGame();
        UIManager.Instance.winPanel.SetActive(false);
        UIManager.Instance.losePanel.SetActive(false);
    }

    void Update()
    {
        if(state != GameState.Playing)
        return;
       
        HandleTimer();
    }

    void StartGame()
    {
    state= GameState.Playing;
    currentTime= maxTime;
     score=0;

     gameEnded=false;

     Debug.Log("Game STarted");
    }

    void HandleTimer()
    {
        currentTime -=Time.deltaTime;
        UIManager.Instance.UpdateTimer(currentTime);
        if(currentTime <=0)
        {
            LoseGame();
        }
    }

    void WinGame()
    {
        gameEnded= true;
        state= GameState.Won;
        UIManager.Instance.Winning();
        Time.timeScale=0;
    }
    void LoseGame()
    {
        gameEnded= true;
        state= GameState.Lost;
       UIManager.Instance.Losing();
    }

    public void AddScore(int dScore)
    {

        if(gameEnded) return;

        score +=dScore;
        UIManager.Instance.UpdateScore(score);
        if(score>= targetScore)
        {
            WinGame();
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale=1;
    }
    }
