using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class openInventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public GameObject pauseMenu;
    public GameObject score;
    public string scene;

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        // press I to open the inventory menu
        if(Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy == false && pauseMenu.activeInHierarchy == false)
        {
            Time.timeScale = 0;
            InventoryManager.Instance.setBears();
            InventoryManager.Instance.getBears();
            inventoryPanel.SetActive(true);
            score.SetActive(false);
        }
        // closes the inventory
        else if(Input.GetKeyDown(KeyCode.I) && inventoryPanel.activeInHierarchy == true)
        {
            Time.timeScale = 1;
            InventoryManager.Instance.setBears();
            inventoryPanel.SetActive(false);
            score.SetActive(true);
        }
    }
}
