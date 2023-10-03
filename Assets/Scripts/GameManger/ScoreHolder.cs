using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreHolder : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private TextMeshProUGUI scoreText;

    public void SetStats(PlayerScore playerScore)
    {
        nameText.text = playerScore._name;
        scoreText.text = playerScore._score.ToString();
    }
}
