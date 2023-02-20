using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DDGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TrackManager RedTrackManager;
    public TrackManager BlueTrackManager;
    public TrackManager GreenTrackManager;
    public TrackManager YellowTrackManager;
    
    public GameObject MainCanvas;
    public GameObject gameEndCanvas;
    public Queue<string> level = new Queue<string>();
    public int score;
    private bool debug;
    //private IEnumerator play;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        StartCoroutine(playLevel());
    }

    // Update is called once per frame
    void Update()
    {
        //auto delete if end is reached
        naturalDelete();
        
        //hit beats
        if (Input.GetKeyDown(KeyCode.A))
        {
            drum("red");
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            drum("blue");
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            drum("green");
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            drum("yellow");
        }

        //spawn beats for testing
        //debug mode only
        if (debug)
        {
            if (Input.GetKeyDown(KeyCode.H))
            {
                spawn("red");
            }
            if (Input.GetKeyDown(KeyCode.J))
            {
                spawn("blue");
            }
            if (Input.GetKeyDown(KeyCode.K))
            {
                spawn("green");
            }
            if (Input.GetKeyDown(KeyCode.L))
            {
                spawn("yellow");
            }
        }
    }

    //drums the designated track and updates score
    //returns true if hit, false if missed
    void drum(string color)
    {
        bool hitDrum = false;
        switch (color)
        {
            case "red":
                hitDrum = RedTrackManager.hitBeat();
                break;
            case "blue":
                hitDrum = BlueTrackManager.hitBeat();
                break;
            case "green":
                hitDrum = GreenTrackManager.hitBeat();
                break;
            case "yellow":
                hitDrum = YellowTrackManager.hitBeat();
                break;
        }

        if (hitDrum)
        {
            score = score + 100;
            scoreText.text = "Score: " + score;
        }
        else
        {
            if (score > 0)
            {
                score = score - 50;
                scoreText.text = "Score: " + score;
            }
        }
    }

    void spawn(string color)
    {
        switch (color)
        {
            case "red":
                RedTrackManager.spawnBeat();
                break;
            case "blue":
                BlueTrackManager.spawnBeat();
                break;
            case "green":
                GreenTrackManager.spawnBeat();
                break;
            case "yellow":
                YellowTrackManager.spawnBeat();
                break;
        }
    }

    void naturalDelete()
    {
        RedTrackManager.naturalDelete();
        BlueTrackManager.naturalDelete();
        GreenTrackManager.naturalDelete();
        YellowTrackManager.naturalDelete();
    }

    IEnumerator playLevel()
    {
        Debug.Log("level started");
        yield return new WaitForSeconds(3);
        while (level.Count != 0) 
        {
            Debug.Log(level.Peek() + " beat spawned");
            spawn(level.Dequeue());
            
            yield return new WaitForSeconds(0.25f);
        }
        //find out how to end level when all beats are gone 
        yield return new WaitForSeconds(3);
        Debug.Log("level ended");
        endLevel();
    }

    void endLevel()
    {
        gameEndCanvas.SetActive(true);
        MainCanvas.SetActive(false);
    }

}
