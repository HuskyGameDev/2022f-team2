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
    void Start()
    {
        finalScoreText.text = "You Lose!\nYour Final Score is: " + gameManager.score;

        if(gameManager.score > 8000)
        {
            if(gameManager.tempoFactor == 0.6f)
            {
                StarBucksManager.Instance.UpdateBucks(1);
                finalScoreText.text = "Congradulations!\nYour Final Score is: " + gameManager.score + "\nYou recive one Starbuck!";
            }
            else if(gameManager.tempoFactor == 0.8f)
            {
                StarBucksManager.Instance.UpdateBucks(2);
                finalScoreText.text = "Congradulations!\nYour Final Score is: " + gameManager.score + "\nYou recive two Starbucks!";
            }
            else if(gameManager.tempoFactor == 1.15f)
            {
                StarBucksManager.Instance.UpdateBucks(3);
                finalScoreText.text = "Congradulations!\nYour Final Score is: " + gameManager.score + "\nYou recive three Starbucks!";
            }
        }
        else
        {
            finalScoreText.text = "You Lose!\nYour Final Score is: " + gameManager.score;
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
