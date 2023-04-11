using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeMenuManager : MonoBehaviour
{
    public GameObject prizeMenu;
    private int prizeVal;
    public GameObject prompt;
    public GameObject rejectPanel;
    public GameObject UI;

    // Start is called before the first frame update
    void Start()
    {
        prizeVal = 10;
        prompt.SetActive(true);
        rejectPanel.SetActive(false);
        UI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // when the player clicks yes
    public void ChoosePrize()
    {
        // if the player has enough star bucks for the prize
        if(StarBucksManager.Instance.GetBucks() == prizeVal)
        {
            // add prize
        }
        else
        {
            prompt.SetActive(false);
            rejectPanel.SetActive(true);
        }
    }
    // when the player clicks no
    public void ExitMenu()
    {
        rejectPanel.SetActive(false);
        prizeMenu.SetActive(false);
        UI.SetActive(true);
    }
}
