using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class DeathMenu : MonoBehaviour
{
    public Image backgroundIMG;
    private bool isShown = false;
    private float transition = 0f;
    [SerializeField] private GameObject DeathMenuHolder;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private Score playerScore;

    void Update()
    {
        
        if (!isShown)
        {
            return;
        }
        else
        {
            //transition += Time.deltaTime;
            //canvasGroup.alpha = transition/2;
        }
        
    }

    public void ToggleDeathMenu()
    {
        DeathMenuHolder.SetActive(true);
        int _score =(int)playerScore.score + (int)coinsCounter.coins * 5;
        score.text = "Score: " +  _score.ToString();
        isShown = true;
        
    }
    

    public void restart()
    { 
        SceneManager.LoadScene("SampleScene");
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
