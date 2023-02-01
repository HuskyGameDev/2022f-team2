using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DDGameManager : MonoBehaviour
{

    public GameObject RedTrack;
    public GameObject BlueTrack;
    public GameObject GreenTrack;
    public GameObject YellowTrack;

    private TrackManager RedTrackManager;
    private TrackManager BlueTrackManager;
    private TrackManager GreenTrackManager;
    private TrackManager YellowTrackManager;

    // Start is called before the first frame update
    void Start()
    {
        RedTrackManager = new TrackManager(GameObject.Find("Red Drum"), GameObject.Find("Red Beat"));
        BlueTrackManager = new TrackManager(GameObject.Find("Blue Drum"), GameObject.Find("Blue Beat"));
        GreenTrackManager = new TrackManager(GameObject.Find("Green Drum"), GameObject.Find("Green Beat"));
        YellowTrackManager = new TrackManager(GameObject.Find("Yellow Drum"), GameObject.Find("Yellow Beat"));
    }

    // Update is called once per frame
    void Update()
    {

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

    }


    void drum(string color)
    {
        switch (color)
        {
            case "red":
                RedTrackManager.hitBeat();
                break;
            case "blue":
                BlueTrackManager.hitBeat();
                break;
            case "green":
                GreenTrackManager.hitBeat();
                break;
            case "yellow":
                YellowTrackManager.hitBeat();
                break;
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

}
