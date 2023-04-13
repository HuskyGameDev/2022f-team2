using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsMenu : MonoBehaviour
{
    public GameObject creditsMenu;

    void Start()
    {
        creditsMenu.SetActive(false);
    }

    // toggles the settings menu
    public void openMenu()
    {
        if(creditsMenu.activeInHierarchy == false)
        {
            creditsMenu.SetActive(true);
        }
        else
        {
            creditsMenu.SetActive(false);
        }
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && creditsMenu.activeInHierarchy == true)
        {
            creditsMenu.SetActive(false);
        }
    }
}
