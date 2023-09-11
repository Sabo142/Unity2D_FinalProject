using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    public event Action<GameState> StateChanged;
    private void Awake()
    {
        Instance = this;
    }
    public void SetGameState(GameState gameState)
    {
        State = gameState;
        StateChanged?.Invoke(State);
    }
}

public enum GameState
{
    Menu,
    Play,
    Dead,
}

