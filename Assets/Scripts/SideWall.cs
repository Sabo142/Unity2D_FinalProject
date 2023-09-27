using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideWall : MonoBehaviour
{
    [SerializeField] int Speed = -3;
    private bool gameIsPaused;

    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }

    void Update()
    {
        if (gameIsPaused) return;
        this.transform.position = this.transform.position + new Vector3(0, Speed, 0) * Time.deltaTime;
        if(this.transform.position.y < -11)
        {
            this.transform.position += new Vector3(0, 22, 0);
        }
    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                {
                    { gameIsPaused = false; }

                }
                break;
            case GameState.PauseMenu:
                {
                    { gameIsPaused = true; }

                }
                break;
            case GameState.Dead:
                {
                    { gameIsPaused = true; }
                }
                break;
        }
    }

}
