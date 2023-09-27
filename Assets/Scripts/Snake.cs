using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour
{
    [SerializeField] private int fallSpeed;
    [SerializeField] Animator animator;
    private bool gameIsPaused;

    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }

    private void Update()
    {
        if (GameManager.Instance.State != GameState.Play) return;
        this.transform.position = this.transform.position + new Vector3(0, fallSpeed, 0) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                {
                    {
                        animator.enabled = true;
                        gameIsPaused = false; }

                }
                break;
            case GameState.PauseMenu:
                {
                    {
                        animator.enabled = false;
                        gameIsPaused = true; 
                    }

                }
                break;
            case GameState.Dead:
                {
                    {
                        animator.enabled = false;
                        gameIsPaused = true; 
                    }
                }
                break;
        }
    }
}
