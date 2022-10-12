using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowdyRacersGame : MonoBehaviour
{

    public GameObject panel;

    public void Start()
    {
        panel = GameObject.Find("BettingPanel");
        panel.SetActive(true);
    }


    public void bet(int racer)
    {
        int winner = generateWinner();
        
        StartCoroutine(raceTime());

        if(racer == winner)
        {
            Debug.Log("You win");
        }
        else
        {
            Debug.Log("You lose");
        }
    }

    public int generateWinner()
    {
        int winner = Random.Range(1, 5);
        Debug.Log("Winner is" + winner);
        return winner;
    }

    IEnumerator raceTime()
    {
        panel.SetActive(false);
        yield return new WaitForSeconds(5);
        panel.SetActive(true);
    }


}
