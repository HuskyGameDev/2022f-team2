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
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
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


        //update all beats
        update();

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
            score = score + 1;
            scoreText.text = "Score: " + score;
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

    void update()
    {

    }

    void naturalDelete()
    {
    }


}
