using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public GameObject settingsPanel;

    void Start()
    {
        settingsPanel.SetActive(false);
    }

    // toggles the settings menu
    public void openMenu()
    {
        if(settingsPanel.activeInHierarchy == false)
        {
            settingsPanel.SetActive(true);
        }
        else
        {
            settingsPanel.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && settingsPanel.activeInHierarchy == true)
        {
            settingsPanel.SetActive(false);
        }
    }
}
