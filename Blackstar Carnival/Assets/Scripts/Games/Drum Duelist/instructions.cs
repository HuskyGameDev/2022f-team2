using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class instructions : MonoBehaviour
{
    public GameObject levelSelectCanvas;
    public GameObject pauseCanvas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void goToInstructions() {
        levelSelectCanvas.SetActive(false);
        pauseCanvas.SetActive(true);
    }

    public void returnToLvl() {
        levelSelectCanvas.SetActive(true);
        pauseCanvas.SetActive(false);
    }
}
