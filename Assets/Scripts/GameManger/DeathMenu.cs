using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Analytics;

public class DeathMenu : MonoBehaviour
{
    public Image backgroundIMG;
    [SerializeField] private GameObject DeathMenuHolder;
    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private TextMeshProUGUI score;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private Score playerScore;
    [SerializeField] private AudioClip deathSound;
    [SerializeField] private AudioSource audioSource;


    public void ToggleDeathMenu()
    {
        DeathMenuHolder.SetActive(true);
        audioSource.enabled = true;
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
