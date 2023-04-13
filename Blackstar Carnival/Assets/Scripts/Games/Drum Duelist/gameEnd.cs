using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class gameEnd : MonoBehaviour
{
    public TextMeshProUGUI finalScoreText;
    public DrumDuelistGameManager gameManager;
    public GameObject levelSelectCanvas;
    public GameObject gameEndCanvas;

    // Start is called before the first frame update
    void OnEnable()
    {
        if(gameManager.score <= 4000)
        {
            finalScoreText.text = "You Lose!\nYour Final Score is: " + gameManager.score;
        }
        if (gameManager.score <= 8000)
        {
            StarBucksManager.Instance.UpdateBucks(1);
            finalScoreText.text = "Congradulations!\nFinal Score: " + gameManager.score + "\nStarbucks earned: 1";
        }
        else if(gameManager.score <= 12000)
        {
            StarBucksManager.Instance.UpdateBucks(2);
            finalScoreText.text = "Congradulations!\nFinal Score: " + gameManager.score + "\nStarbucks earned: 2";
        }
        else
        {
            StarBucksManager.Instance.UpdateBucks(3);
            finalScoreText.text = "Congradulations!\nFinal Score: " + gameManager.score + "\nStarbucks earned: 3";
        }

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
