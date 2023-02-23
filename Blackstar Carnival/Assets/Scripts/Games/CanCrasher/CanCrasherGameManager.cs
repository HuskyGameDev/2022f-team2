using BlackstarCarnival.Games.CanCrasher;
using UnityEngine;
public enum CanCrasherGameState
{
    Menu,
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
    
    public void SetGameState(CanCrasherGameState gameState)
    {
        _gameState = gameState;
        switch (gameState)
        {
            case CanCrasherGameState.Lose:
                CanCrasherUIManager.Instance.ShowLosePanel();
                break;
            case CanCrasherGameState.Win:
                CanCrasherUIManager.Instance.ShowWinPanel();
                StarBucksManager.Instance.UpdateBucks(1);
                break;
            case CanCrasherGameState.Menu:
                CanCrasherUIManager.Instance.ShowMenuPanel();
                break;
            case CanCrasherGameState.Playing:
                CanCrasherUIManager.Instance.ShowPlayingPanel();
                break;
        }
    }
}
