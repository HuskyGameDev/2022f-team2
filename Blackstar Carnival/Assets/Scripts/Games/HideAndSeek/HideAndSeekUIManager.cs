using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideAndSeekUIManager : MonoBehaviour
{
    public GameObject LosePanel;
    public GameObject WinPanel;
    public GameObject menuPanel;
    public GameObject player;
    public static HideAndSeekUIManager Instance;
    // Start is called before the first frame update

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

    public void ShowLosePanel(){
        LosePanel.SetActive(true);
        WinPanel.SetActive(false);
        player.SetActive(false);
    }

    public void ShowWinPanel(){
        LosePanel.SetActive(false);
        WinPanel.SetActive(true);
        player.SetActive(false);
    }

    public void ShowPlayingPanel(){
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
        menuPanel.SetActive(false);
        player.SetActive(true);
    }
}
