using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject drum;
    public GameObject beatFab;
    public GameObject track;
    private RectTransform drumRectTransform;
    private RectTransform trackRectTransform;
    private Queue<GameObject> beatQueue;

    private string color;
    private float hitThreshold = 60;

   public void Start()
    {
        drumRectTransform = drum.GetComponent<RectTransform>();
        drumRectTransform.anchoredPosition = new Vector3(0, 40, 0);
        trackRectTransform = track.GetComponent<RectTransform>();
    }
 
    public void spawnBeat()
    {
        GameObject newBeat = Instantiate(beatFab, trackRectTransform) as GameObject;
        newBeat.SetActive(true);
        beatQueue.Enqueue(newBeat);
    }

    public void naturalDelete()
    {
        if(getY(beatQueue.Peek()) < 40)
        {
            Destroy(beatQueue.Dequeue());
            Debug.Log(color + " naturally deleted");
        }
    }

    //checks if beat is hit
    public bool hitBeat()
    {
        if (isHit())
        {
            Destroy(beatQueue.Dequeue());
            return true;
        }
        else
        {
            Destroy(beatQueue.Dequeue());
            return false;
        }
    }

    bool isHit()
    {
        if( (getY(beatQueue.Peek()) > getY(drum)) && (getY(beatQueue.Peek()) < getY(drum) + hitThreshold) )
        {
            return true;
        }
        return false;
    }

    float getY(GameObject gameObject)
    {
        return gameObject.GetComponent<RectTransform>().anchoredPosition.y;
    }
}
