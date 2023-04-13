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
        finalScoreText.text = "You Lose!\nYour Final Score is: " + gameManager.score;

        if (gameManager.score > 4000 && gameManager.tempoFactor == 0.6f)
        {
            StarBucksManager.Instance.UpdateBucks(1);
            finalScoreText.text = "Congradulations!\nFinal Score: " + gameManager.score + "\nStarbucks earned: 1";
        }
        else if(gameManager.score > 6000 && gameManager.tempoFactor == 0.8f)
        {
            StarBucksManager.Instance.UpdateBucks(2);
            finalScoreText.text = "Congradulations!\nFinal Score: " + gameManager.score + "\nStarbucks earned: 2";
        }
        else if(gameManager.score > 12000 && gameManager.tempoFactor == 1.15f)
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
