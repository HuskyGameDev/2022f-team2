using System;
using System.Collections;
using System.Collections.Generic;
using BlackstarCarnival;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransitionManager : MonoBehaviour
{
    public static SceneTransitionManager Instance;
    public Animator transition;
    PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    public void LoadScene(string sceneName)
    {
        // TODO: Add a loading screen
        SceneManager.LoadScene(sceneName);
        var save = SaveData.Current;
        save.currentScene = sceneName;
        if (player != null)
        {
            player.transform.position = save.playerPosition;
            player.transform.rotation = FaceDirectionUtility.GetRotation(save.faceDirection);
        }
        
    }
}
