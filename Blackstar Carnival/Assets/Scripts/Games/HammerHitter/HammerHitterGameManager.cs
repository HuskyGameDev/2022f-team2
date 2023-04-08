using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum HammerHitterGameState
{
    Menu,
    Playing,
    Win,
    Lose,
}


    
public class HammerHitterGameManager : MonoBehaviour
{
    public static HammerHitterGameManager Instance;

    //private StarBucksManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //manager = GameObject.Find("StarBucksManager").GetComponent<StarBucksManager>(); 
    }

    private HammerHitterGameState _gameState = HammerHitterGameState.Playing;
    public HammerHitterGameState GameState
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

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetGameState(HammerHitterGameState state)
    {
        _gameState = state;
        switch (state)
        {
            case HammerHitterGameState.Lose:
                HammerHitterUIManager.Instance.ShowLosePanel();
                break;

            case HammerHitterGameState.Win:
                HammerHitterUIManager.Instance.ShowWinPanel();

                StarBucksManager.Instance.UpdateBucks(1);
                //manager.UpdateBucks(1);
                //Debug.Log("Added star buck");

                break;
            case HammerHitterGameState.Menu:
                HammerHitterUIManager.Instance.ShowMenuPanel();
                break;

            case HammerHitterGameState.Playing:
                HammerHitterUIManager.Instance.ShowPlayingPanel();
                break;
        }
    }
}
