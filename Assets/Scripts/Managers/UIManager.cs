using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class UIManager : MonoBehaviour
{
    public static UIManager Instance;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI eggText;
    public TextMeshProUGUI timeText;

    public GameObject winPanel;
    public GameObject losePanel;


    void Awake()
    {
        Instance= this;
        
    }

    public void UpdateScore(int score)
    {
        scoreText.text= "Score: " + score;
    }


    public void UpdateTimer(float time)
    {
        timeText.text= "Time: "+ Mathf.Ceil(time); 
        
        
     }


     public void Winning()
    {
        winPanel.SetActive(true);
    }


    public void Losing()
    {
        losePanel.SetActive(true);
    }
}
