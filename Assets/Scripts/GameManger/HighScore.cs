using UnityEngine;
using System.Collections.Generic;
[CreateAssetMenu(menuName = "HighScore")]
public class HighScore : ScriptableObject
{
    [SerializeField] private List<PlayerScore> scoreList;
    public string PlayerName = "xxx";
    public List<PlayerScore> ScoreList { get {  return scoreList; } }
    public bool CheckForHighScore(int score)
    {
        if (ScoreList.Count < 14) return true;
        if (score > scoreList[scoreList.Count-1]._score)
        {   
            return true;
        }
        return false;
    }
    public void InsertNewHighScore(int score)
    {
        organizeHighScore();
        PlayerScore playerScore = new PlayerScore(PlayerName, score);
        for (int i = 0; i <= scoreList.Count - 1; i++)
        {
            if (score > scoreList[i]._score)
            {
                
                scoreList.Insert(i, playerScore);
                if(scoreList.Count > 14)
                {
                    scoreList.RemoveAt(scoreList.Count-1);
                }
                return;
            }
        }
        if (scoreList.Count < 14)
        {
            scoreList.Insert(scoreList.Count, playerScore);
        }
    }
    public void organizeHighScore()
    {
        for(int y = scoreList.Count ^ 2 - 1; y > 0;y--)
        {
            for (int i = scoreList.Count - 1; i > 0; i--)
            {
                if (scoreList[i]._score > scoreList[i-1]._score)
                {
                    PlayerScore tempScore = scoreList[i];
                    scoreList[i] = scoreList[i -1];
                    scoreList[i -1] = tempScore;
                }
            }
        }
        
    }
}
[System.Serializable]
public class PlayerScore
{
    public string _name;
    public int _score;
    public PlayerScore (string name, int score)
    {
        _name = name;
        _score = score;
    }
}