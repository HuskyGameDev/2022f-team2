using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DrumDuelistGameManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI beatsHitText;
    public TrackManager RedTrackManager;
    public TrackManager BlueTrackManager;
    public TrackManager GreenTrackManager;
    public TrackManager YellowTrackManager;

    public GameObject MainCanvas;
    public GameObject gameEndCanvas;
    public GameObject levelSelect;

    public int score;
    public int hitBeats;
    private int actualBeatsHit;

    public Dictionary<string, object> levelInfo;  
    public float tempoFactor;

    private bool debug;

    void OnEnable()
    {
        score = 0;
        hitBeats = 0;
        actualBeatsHit = 0;
        scoreText.text = "Score: 0";
        beatsHitText.text = "Beats Hit: 0";

        levelInfo = levelSelect.GetComponent<levelSelect>().levelInfo;

        tempoFactor = (float)levelInfo["tempoFactor"];
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
            actualBeatsHit++;
            scoreText.text = "Score: " + score;
            beatsHitText.text = "Beats Hit: " + actualBeatsHit;

        }
        else
        {
            if (score > 0)
            {
                score = score - 50;
                scoreText.text = "Score: " + score;
            }
        }
        hitBeats++;
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
        if (RedTrackManager.naturalDelete() || BlueTrackManager.naturalDelete() ||
            GreenTrackManager.naturalDelete() || YellowTrackManager.naturalDelete())
        {
            hitBeats++;
        }
    }

    IEnumerator playLevel()
    {
        Queue<string> level = (Queue<string>)levelInfo["level"];
        int totalBeats = level.Count;
        Debug.Log("level started. total beats: " + System.Convert.ToString(totalBeats));
        yield return new WaitForSeconds(3);

        //normal mode
        if (!(bool)levelInfo["chordMode"])
        {
            while (level.Count != 0)
            {
                Debug.Log(level.Peek() + " beat spawned");
                spawn(level.Dequeue());
                yield return new WaitForSeconds(0.4f / (float)(levelInfo["tempoFactor"]));
            }
        }
        else
        {
            while (level.Count != 0)
            {
                spawn(level.Dequeue());
                spawn(level.Dequeue());
                yield return new WaitForSeconds(0.5f * (float)(levelInfo["tempoFactor"]));
            }
        }

            Debug.Log("Level Over!");
            Debug.Log("hitBeats " + System.Convert.ToString(hitBeats));
            yield return new WaitForSeconds(3.0f);
            endLevel();

            //find out how to end level when all beats are gone 
        }
    

    void endLevel()
    {
        gameEndCanvas.SetActive(true);
        levelSelect.SetActive(false);
        MainCanvas.SetActive(false);
    }

}
