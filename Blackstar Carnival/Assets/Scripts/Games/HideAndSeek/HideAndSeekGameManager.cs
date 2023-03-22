using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HideAndSeekGameState
{
    Menu,
    Playing,
    Win,
    Lose,
}

public class HideAndSeekGameManager : MonoBehaviour
{

    int winningTent;
    public static HideAndSeekGameManager Instance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private HideAndSeekGameState _gameState = HideAndSeekGameState.Playing;
    public HideAndSeekGameState GameState
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

    void setTent(){
        winningTent = Random.Range(1, 4);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
