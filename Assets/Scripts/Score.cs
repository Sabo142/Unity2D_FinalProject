using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0f;
    [SerializeField] private TMP_Text scoreText;
    private bool alive = true;
    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChange;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChange;
    }
    void Update()
    {
        if (alive)
        {
            score += Time.deltaTime;
            scoreText.text = ((int)score).ToString();
        }
        
    }
    private void OnGameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Dead:
                {
                    alive = false;
                }
                break;
                
                
        }
    }
}
