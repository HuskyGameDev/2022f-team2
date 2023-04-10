using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RowdyRacersGame : MonoBehaviour
{

    public GameObject betPanel;
    public GameObject resultPanel;
    public GameObject animationPanel;
    public GameObject result;
    public TextMeshProUGUI resultText;

    //private GameManager manager;

    public void Start()
    {
        //betPanel = GameObject.Find("BettingPanel");
        betPanel.SetActive(true);
        //resultPanel = GameObject.Find("Result Panel");
        resultPanel.SetActive(false);
        animationPanel.SetActive(false);
        //result = GameObject.Find("Result Panel/Result");
        resultText = result.GetComponent<TextMeshProUGUI>();
    }

    public void bet(int racer)
    {
        // all the stuff that needs the wait needs to be in here
        StartCoroutine(raceTime(racer));
    }

    public List<int> generatePositions()
    {
        //indecies are races value is the place they finished in
        int[] a = { 1, 2, 3, 4 };
        List<int> positions = new List<int>( a );

        
        for(int i = 0; i < Random.Range(50,100); i++)
        {
            swap(Random.Range(0, 4), Random.Range(0, 4), positions);
        }

        Debug.Log("Winner is " + positions[0]);
        return positions;
    }

    public void swap(int a, int b, List<int> list)
    {
        int temp = list[a];
        list[a] = list[b];
        list[b] = temp;
    }

    IEnumerator raceTime(int racer)
    {
        //decide winner
        List<int> racerPositions = generatePositions();

        betPanel.SetActive(false);
        animationPanel.SetActive(true);
        yield return new WaitForSeconds(5);
        animationPanel.SetActive(false);

        //display results
        resultPanel.SetActive(true);

        if (racer == racerPositions[0])
        {
            Debug.Log("Win");
            resultText.text = $"You Win!\n";
            Debug.Log($"{racerPositions[0]} {racerPositions[1]} {racerPositions[2]} {racerPositions[3]}");
            
            StarBucksManager.Instance.UpdateBucks(1);
        }
        else if (racer == racerPositions[1])
        {
            resultText.text = $"Second Place!\n Racer {racerPositions[0]} has won";
            Debug.Log($"{racerPositions[0]} {racerPositions[1]} {racerPositions[2]} {racerPositions[3]}");
        }
        else if (racer == racerPositions[2])
        {
            resultText.text = $"Third Place!\n Racer {racerPositions[0]} has won";
            Debug.Log($"{racerPositions[0]} {racerPositions[1]} {racerPositions[2]} {racerPositions[3]}");
        }
        else
        {
            resultText.text = $"Last Place!\n Racer {racerPositions[0]} has won";
            Debug.Log($"{racerPositions[0]} {racerPositions[1]} {racerPositions[2]} {racerPositions[3]}");
        }
    }

    public void playAgain()
    {
        betPanel.SetActive(true);
        resultPanel.SetActive(false);
    }

}
