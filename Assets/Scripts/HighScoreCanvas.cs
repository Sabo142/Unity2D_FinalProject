using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HighScoreCanvas : MonoBehaviour
{
    [SerializeField] private List<ScoreHolder> scoreHolders;
    [SerializeField] private HighScore highScoreList;

    [ContextMenu("Show Score")]
    public void AddToList()
    {
        for (int i = 0; i < highScoreList.ScoreList.Count; i++) 
        {
            scoreHolders[i].gameObject.SetActive(true);
            scoreHolders[i].SetStats(highScoreList.ScoreList[i]);

        }
    }
    public void GoToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }

}
