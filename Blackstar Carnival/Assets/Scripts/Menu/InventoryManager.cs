using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public static bool done = false;

    public GameObject blackBear;
    public GameObject brownBear;
    public GameObject polarBear;
    public GameObject panda;

    public static InventoryManager Instance;
    public List<string> items = new List<string>();
    void Awake()
    {
        if(!done)
        {
            done = true;
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Update()
    {/*
        blackBear = GameObject.Find("BlackBear");
        brownBear = GameObject.Find("BrownBear");
        polarBear = GameObject.Find("PolarBear");
        panda = GameObject.Find("Panda");*/
    }
/*
    public void getBears()
    {
        if(!(items.Contains("black_bear"))) { blackBear.SetActive(false); }
        if(!(items.Contains("brown_bear"))) { brownBear.SetActive(false); }
        if(!(items.Contains("polar_bear"))) { polarBear.SetActive(false); }
        if(!(items.Contains("panda"))) { panda.SetActive(false); }
    }

    public void setBears()
    {
        blackBear.SetActive(true);
        brownBear.SetActive(true);
        polarBear.SetActive(true);
        panda.SetActive(true);
    }*/

    public void addItem(string newItem)
    {
        items.Add(newItem);
    }
}
