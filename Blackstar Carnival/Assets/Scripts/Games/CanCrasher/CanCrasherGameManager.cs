using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum CanCrasherGameState
{
    None,
    Playing,
    Win,
    Lose
}

public class CanCrasherGameManager : MonoBehaviour
{
    public static CanCrasherGameManager Instance;
    //private CanCrasherGameState _gameState = CanCrasherGameState.None;
    private CanCrasherGameState _gameState = CanCrasherGameState.Playing;
    public CanCrasherGameState GameState
    {
        get => _gameState;
        set => _gameState = value;
    }
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
