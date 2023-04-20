using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prizeMenuManager : MonoBehaviour
{
    public GameObject prizeMenu;
    public int prizeVal;
    public GameObject prompt;
    public GameObject rejectPanel;
    public GameObject UI;
    public bool bought;

    // makes an object for the bear
    public static prizeMenuManager Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        bought = false;
        prizeVal = 5;
        prompt.SetActive(true);
        rejectPanel.SetActive(false);
        UI.SetActive(false);
    }

    // when the player clicks yes
    public void ChoosePrize()
    {
        // if the player has enough star bucks for the prize
        if(StarBucksManager.Instance.GetBucks() >= prizeVal)
        {
            bought = true;
            ExitMenu();
        }
        else
        {
            bought = false;
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
