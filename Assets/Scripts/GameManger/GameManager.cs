using UnityEngine;
using System;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State = GameState.Play;
    public static event Action<GameState> StateChanged;
    public string PlayerName = "name";
    public float GameSpeed = 1;
    private float timer = 0f;
    private void Awake()
    {
        Instance = this;
        State = GameState.Play;
    }
    public void SetGameState(GameState gameState)
    {
        State = gameState;
        StateChanged?.Invoke(State);

    }
    private void Update()
    {
        timer += Time.deltaTime;
        if(timer > 20f) 
        {
            timer = 0f;
            GameSpeed += 0.5f;
        }
    }
}
public enum GameState
{
    PauseMenu,
    Play,
    Dead,
}