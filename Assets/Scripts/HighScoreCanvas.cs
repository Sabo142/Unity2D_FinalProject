using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreCanvas : MonoBehaviour
{
    [SerializeField] private List<ScoreHolder> scoreHolders;
    [SerializeField] private HighScore highScoreList;
    [SerializeField] private Score scoreCanvas;
    [SerializeField] private CoinsCounter coinsCounter;
    [SerializeField] private GameObject NewHighScoreText;
    [SerializeField] private GameObject HighScoreCanvasHolder;

    private void Awake()
    {
        GameManager.StateChanged += OnStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnStateChanged;
    } 
    [ContextMenu("Show Score")]
    public void AddToList()
    {
        for (int i = 0; i < highScoreList.ScoreList.Count; i++) 
        {
            scoreHolders[i].gameObject.SetActive(true);
            scoreHolders[i].SetStats(highScoreList.ScoreList[i]);

        }
    }
    void OnStateChanged(GameState gameState)
    {
        Debug.Log(gameState.ToString());
        switch (gameState)
        {
            case GameState.Dead:
                {
                    CheckForNewHighScore();
                    
                    break;
                }
            case GameState.Play:
                {
                     break;
                }
        }

    }
    public void CheckForNewHighScore()
    {
        int finalScore = (int)scoreCanvas.score + (int)(coinsCounter.coins * 5);

        if(highScoreList.CheckForHighScore(finalScore))
        {
            NewHighScoreText.SetActive(true);
            highScoreList.InsertNewHighScore(finalScore);
            
        }
        AddToList();

    }
   
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void GoToHighScoreTable()
    {
        HighScoreCanvasHolder.SetActive(true);
        NewHighScoreText.SetActive(false);
        Debug.Log("GoToHighScore");
    }

}
