using System;
using UnityEngine;
public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State = GameState.Play;
    public static event Action<GameState> StateChanged;
    public string PlayerName = "name";
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
}
public enum GameState
{
    PauseMenu,
    Play,
    Dead,
}