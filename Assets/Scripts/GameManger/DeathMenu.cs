using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class DeathMenu : MonoBehaviour
{
   /* public void SendCustomEvent()
    {

        
        AnalyticsEvent.Custom("PlayerScore", new
        {
            Score = 100,
        });
    }*/

    public Image backgroundIMG;
    [SerializeField] private GameObject DeathMenuHolder;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private Score playerScore;
    public AudioClip deathSound;



    public void ToggleDeathMenu()
    {
        DeathMenuHolder.SetActive(true);
        // AudioSource.PlayClipAtPoint(deathSound, transform.position);
        int _score = (int)playerScore.score + (int)coinsCounter.coins * 5;
        score.text = "Score: " + _score.ToString();

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
