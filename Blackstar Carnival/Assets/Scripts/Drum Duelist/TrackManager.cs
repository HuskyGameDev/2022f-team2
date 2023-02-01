using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager
{
    private GameObject drum;
    private GameObject beat;
    private float top = 315;
    private float bottom = -315;
    private string color;
    private float tempo = 200;
    private float hitThreshold = 60;

    public TrackManager(GameObject drum, GameObject beat, int bottom, int top, string color)
    {
        this.drum = drum;
        this.beat = beat;
        this.bottom = bottom;
        this.top = top;
        this.color = color;

        beat.SetActive(false);
        drum.transform.localPosition = new Vector3(0, bottom, 0);
        beat.transform.localPosition = new Vector3(0, top, 0);
    }

 
    public void spawnBeat()
    {
        //checks if beat is on screen
        //if not spawn beat
        //if yes do nothing
        if (beat.activeSelf == false)
        {
            //spawn beat on top of screen
            beat.transform.localPosition = new Vector3(0, top, 0);
            beat.SetActive(true);
        }
    }

    public void moveBeat()
    {
        if(beat.activeSelf == true)
        {
            beat.transform.Translate(0, (float)-1/tempo, 0);
        }
    }

    public void naturalDelete()
    {
        if( (getY(beat) < bottom) && beat.activeSelf)
        {
            beat.SetActive(false);
            Debug.Log(color + " naturally deleted");
        }
    }

    //checks if beat is hit
    public bool hitBeat()
    {
        beat.SetActive(false);
        if (isHit())
        {
            Debug.Log(color + " beat hit    " + "   Get y for beat " + getY(beat));
            return true;
        }
        else
        {
            Debug.Log(color + " beat missed       " + "   Get y for beat " + getY(beat));
            Debug.Log("Drum Y " + getY(drum));
            return false;
        }
    }


    bool isHit()
    {
        if( (getY(beat) > getY(drum)) && (getY(beat) < getY(drum) + hitThreshold) )
        {
            return true;
        }
        return false;
    }

    public bool isActive()
    {
        return beat.activeSelf;
    }

    float getY(GameObject gameObject)
    {
        return gameObject.transform.localPosition.y;
    }
}
