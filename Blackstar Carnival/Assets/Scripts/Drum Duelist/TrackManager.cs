using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject drum;
    public GameObject beat;
    public float secondCounter;
    private float top = 150;
    private float bottom = -160;
    private float speedFactor = 200;

    public TrackManager(GameObject drum, GameObject beat)
    {
        this.drum = drum;
        this.beat = beat;
        beat.SetActive(false);
        drum.transform.localPosition = new Vector3(0, bottom, 0);
        beat.transform.localPosition = new Vector3(0, top, 0);
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //check if beat needs to be deleted
        deleteBeat();

        //move beat
        moveBeat();

        //spawn beat if a is pressed
        if (Input.GetKeyDown(KeyCode.A))
        {
            spawnBeat();
        }
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

    void moveBeat()
    {
        if(beat.activeSelf == true)
        {
            beat.transform.Translate(0, (float)-1/speedFactor, 0);
        }
    }

    void deleteBeat()
    {
        //if beat hits end delete
        if(beat.transform.localPosition.y == bottom)
        {
            beat.SetActive(false);
        }
    }

    //checks if beat is hit
    public void hitBeat()
    {
        if (isHit())
        {
            Debug.Log("Beat Hit");
        }
        else
        {
            Debug.Log("Beat missed");
        }
    }



    bool isHit()
    {
        if( (getY(beat) > getY(drum)) && getY(beat) < getY(drum) + 20.0)
        {
            return true;
        }
        return false;
    }

    float getY(GameObject gameObject)
    {
        return gameObject.transform.position.y;
    }
}
