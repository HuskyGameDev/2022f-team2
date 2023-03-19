using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public DDGameManager gameManager;
    public GameObject levelSelectCanvas;
    public GameObject gameEndCanvas;

    // Start is called before the first frame update
    void Start()
    {
        finalScoreText.text = "Congradulations\nYour Final Score is: " + gameManager.score;
    }

    public void playAgain()
    {
        levelSelectCanvas.SetActive(true);
        gameEndCanvas.SetActive(false);
    }

    public void quit()
    {
        levelSelectCanvas.SetActive(true);
        gameEndCanvas.SetActive(false);
        SceneManager.LoadScene("Carnival");
    }
}
