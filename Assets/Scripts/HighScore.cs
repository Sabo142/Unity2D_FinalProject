using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "HighScore")]
public class HighScore : ScriptableObject
{
    [SerializeField] private List<PlayerScore> scoreList = new List<PlayerScore>();
    public List<PlayerScore> ScoreList { get {  return scoreList; } }
    public void AddHighScore(string name, int score)
    {
        PlayerScore newPlayerScore = new PlayerScore(name, score);
        scoreList.Add(newPlayerScore);
        organizeHighScore();
    }
    public bool CheckForHighScore(int score)
    {
        if (score < scoreList[scoreList.Count]._score)
        {
            
            return true;

        }
        return false;
    }
    public void organizeHighScore()
    {
        for(int y = 0; y < (scoreList.Count^2-1);)
        {
            for (int i = 0; i < scoreList.Count-1; i++)
            {
                if (scoreList[i]._score > scoreList[i + 1]._score)
                {
                    PlayerScore tempScore = scoreList[i];
                    scoreList[i] = scoreList[i + 1];
                    scoreList[i + 1] = tempScore;
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
