using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DrumDuelistUIManager : MonoBehaviour
{
    public static DrumDuelistUIManager Instance;
    public GameObject MainPanel;
    public GameObject MenuPanel;

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

    public void ShowPlayingPanel(){
        MainPanel.SetActive(true);
        MenuPanel.SetActive(false);
    }

    public void ShowMenuPanel(){
        MainPanel.SetActive(false);
        MenuPanel.SetActive(true);
    }

}
