using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RowdyRacersGame : MonoBehaviour
{

    public GameObject betPanel;
    public GameObject resultPanel;
    public GameObject result;
    public TextMeshProUGUI resultText;

    public void Start()
    {
        betPanel = GameObject.Find("BettingPanel");
        betPanel.SetActive(true);
        resultPanel = GameObject.Find("Result Panel");
        resultPanel.SetActive(false);
        result = GameObject.Find("Result Panel/Result");
        resultText = result.GetComponent<TextMeshProUGUI>();
    }

    public void bet(int racer)
    {
        //decide winner
        int winner = generateWinner();


        //wait x seconds
        StartCoroutine(raceTime(5));

        //play race animation in the meantime
        
        //display results
        resultPanel.SetActive(true);

        if (racer == winner)
        {
            resultText.text = $"You Win!";
        }
        else
        {
            resultText.text = $"You Lost!\n Racer {winner} has won";
        }

    }

    public int generateWinner()
    {
        int winner = Random.Range(1, 5);
        Debug.Log("Winner is " + winner);
        return winner;
    }

    IEnumerator raceTime(int time)
    {
        betPanel.SetActive(false);
        yield return new WaitForSeconds(time);
    }

    public void playAgain()
    {
        betPanel.SetActive(true);
        resultPanel.SetActive(false);
    }

}
