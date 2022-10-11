using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RowdyRacersGame : MonoBehaviour
{
    
    public void bet(int racer)
    {
        int winner = generateWinner();
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
}
