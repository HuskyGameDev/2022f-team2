using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class StarBucksManager : MonoBehaviour
{
    public static StarBucksManager Instance;
    public int starBucks;

    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        // initializes # of star bucks to 0 when new game started
        starBucks = 0;
    }

    // have the games each call this method when the player gains points
    // adds the given # of star bucks to the total and updates the scoreboard UI
    public void UpdateBucks(int add)
    {
        Debug.Log("Updating bucks, total: " + starBucks);
        starBucks += add;
    }

    public void ResetBucks()
    {
        // when the game is exited we want to reset the star bucks
        starBucks = 0;
    }

    public int GetBucks()
    {
        return starBucks;
    }
}
