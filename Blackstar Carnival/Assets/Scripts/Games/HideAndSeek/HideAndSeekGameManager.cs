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
    public AudioSource found;

    int winningTent;
    public static HideAndSeekGameManager Instance;

    // Start is called before the first frame update
    void Start()
    {
        setTent();
        //found = GetComponent<AudioSource>();
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

    public void checkResults(GameObject g){
        switch(winningTent){
                case 1:
                    if(g.transform.parent.gameObject.name == "RedTent1"){
                        StartCoroutine(endGame(true));
                    }
                    break;
                case 2:
                    if(g.transform.parent.gameObject.name == "RedTent2"){
                        StartCoroutine(endGame(true));
                    }
                    break;
                case 3:
                    if(g.transform.parent.gameObject.name == "RedTent3"){
                        StartCoroutine(endGame(true));
                    }
                    break;
                case 4:
                    if(g.transform.parent.gameObject.name == "RedTent4"){
                        StartCoroutine(endGame(true));
                    }
                    break;
                default:
                    StartCoroutine(endGame(false));
                    break;
        }
    }

    IEnumerator endGame(bool win)
    {
        if(win)
        {
            found.Play();
            yield return new WaitForSeconds(1);
            SetGameState(HideAndSeekGameState.Win);
        }
        else { SetGameState(HideAndSeekGameState.Lose); }
    }

    public void SetGameState(HideAndSeekGameState state)
    {
        _gameState = state;
        switch (state)
        {
            case HideAndSeekGameState.Lose:
                HideAndSeekUIManager.Instance.ShowLosePanel();
                break;

            case HideAndSeekGameState.Win:
                HideAndSeekUIManager.Instance.ShowWinPanel();

                StarBucksManager.Instance.UpdateBucks(1);

                break;
            case HideAndSeekGameState.Menu:
            //    HideAndSeekUIManager.Instance.ShowMenuPanel();
            //    break;

            case HideAndSeekGameState.Playing:
                HideAndSeekUIManager.Instance.ShowPlayingPanel();
                break;
        }
    }

}