using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Unity.Services.Core;
using Unity.Services.Analytics;


public class MainMenu : MonoBehaviour
{
    [SerializeField] private HighScore highScore;

    void start()
    {
        AnalyticsService.Instance.StartDataCollection();
    }
    public void OnNameTextChange(string input)
    {
        highScore.PlayerName = input;
    }
    public void ToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
