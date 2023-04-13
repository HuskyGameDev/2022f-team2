using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsMenu : MonoBehaviour
{
    public GameObject controlsMenu;

    void Start()
    {
        controlsMenu.SetActive(false);
    }

    // toggles the settings menu
    public void openMenu()
    {
        if(controlsMenu.activeInHierarchy == false)
        {
            controlsMenu.SetActive(true);
        }
        else
        {
            controlsMenu.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && controlsMenu.activeInHierarchy == true)
        {
            controlsMenu.SetActive(false);
        }
    }
}
