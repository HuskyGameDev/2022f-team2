
using System;
using BlackstarCarnival.Games.CanCrasher;
using UnityEngine;

public class CanCrasherStageManager : MonoBehaviour
{
    public static CanCrasherStageManager Instance;

    public GameObject BallPrefab;
    public Transform BallSpawnPoint;

    private int _cansLeft, _ballsLeft;
    public int Balls, Cans;
    
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
        ResetStage();
    }

    public void SpawnBall()
    {
        CanCrasherUIManager.Instance.HideSwipeArrow();
        if (_ballsLeft > 0 && _cansLeft > 0)
        {
            CanCrasherSwipeController.Instance.Ball = Instantiate(BallPrefab, BallSpawnPoint.position, Quaternion.identity);
            _ballsLeft--;
            CanCrasherUIManager.Instance.UpdateBallsLeft(_ballsLeft);
        } else if (CanCrasherGameManager.Instance.GameState == CanCrasherGameState.Playing)
        {
            CanCrasherGameManager.Instance.SetGameState(CanCrasherGameState.Lose);  
            //TODO : Show lose screen and play corresponding sound
        }
    }

    public void ResetStage()
    {
        _cansLeft = Cans;
        _ballsLeft = Balls;
        CanCrasherUIManager.Instance.UpdateCansLeft(_cansLeft);
        CanCrasherUIManager.Instance.UpdateBallsLeft(_ballsLeft);
        SpawnBall();
        // TODO: display balls and cans left
    }
    
    public void CanDestroyed()
    {
        _cansLeft--;
        CanCrasherUIManager.Instance.UpdateCansLeft(_cansLeft);
        // TODO: display balls and cans left
        if (_cansLeft <= 0 && CanCrasherGameManager.Instance.GameState == CanCrasherGameState.Playing)
        {
            CanCrasherGameManager.Instance.SetGameState(CanCrasherGameState.Win); 
            // TODO : Show win screen and play corresponding sound
        }
    }
}