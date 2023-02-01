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
    
    int bottom = -160;
    int top = 150;
    
    // Start is called before the first frame update
    void Start()
    {
        RedTrackManager = new TrackManager(GameObject.Find("Red Drum"), GameObject.Find("Red Beat"), bottom, top, "red");
        BlueTrackManager = new TrackManager(GameObject.Find("Blue Drum"), GameObject.Find("Blue Beat"), bottom, top, "blue");
        GreenTrackManager = new TrackManager(GameObject.Find("Green Drum"), GameObject.Find("Green Beat"), bottom, top, "green");
        YellowTrackManager = new TrackManager(GameObject.Find("Yellow Drum"), GameObject.Find("Yellow Beat"), bottom, top, "yellow");
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

    void update()
    {
        RedTrackManager.moveBeat();
        BlueTrackManager.moveBeat();
        GreenTrackManager.moveBeat();
        YellowTrackManager.moveBeat();
    }

    void naturalDelete()
    {
        if (RedTrackManager.isActive())
        {
            RedTrackManager.naturalDelete();
        }
        if (BlueTrackManager.isActive())
        {
            BlueTrackManager.naturalDelete();
        }
        if (GreenTrackManager.isActive())
        {
            GreenTrackManager.naturalDelete();
        }
        if (YellowTrackManager.isActive())
        {
            YellowTrackManager.naturalDelete();
        }
    }


}
