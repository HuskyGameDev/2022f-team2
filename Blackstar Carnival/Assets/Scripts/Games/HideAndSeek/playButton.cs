using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playButton : MonoBehaviour
{
    public Button playB;
    // Start is called before the first frame update
    void Start()
    {
        playB.onClick.AddListener(play);
    }

    public void play(){
        HideAndSeekGameManager.Instance.SetGameState(HideAndSeekGameState.Playing);
    }
}
