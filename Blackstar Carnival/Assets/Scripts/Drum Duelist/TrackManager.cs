using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public GameObject drum;
    public GameObject beatFab;
    public GameObject track;
    public string color;
    private RectTransform drumRectTransform;
    private RectTransform trackRectTransform;
    private Queue<GameObject> beatQueue = new Queue<GameObject>();

    private int hitThreshold = 80;
   public void Start()
    {
        drumRectTransform = drum.GetComponent<RectTransform>();
        drumRectTransform.anchoredPosition = new Vector3(0, 40, 0);
        trackRectTransform = track.GetComponent<RectTransform>();
    }
 
    public void spawnBeat()
    {
        Debug.Log(color + " beat spawned");
        GameObject newBeat = Instantiate(beatFab, trackRectTransform) as GameObject;
        newBeat.SetActive(true);
        beatQueue.Enqueue(newBeat);
    }

    public void naturalDelete()
    {
        if (beatQueue.Count == 0)
        {
            return;
        }
        if (getY(beatQueue.Peek()) < trackRectTransform.rect.height * -1)
        {
            Debug.Log(color + " beat naturally deleted at y =" + getY(beatQueue.Peek()));
            Destroy(beatQueue.Dequeue());
        }
    }

    //checks if beat is hit
    public bool hitBeat()
    {
        if (beatQueue.Count == 0)
        {
            return false;
        }
        
        if (isHit())
        {
            Destroy(beatQueue.Dequeue());
            Debug.Log(color + " beat hit");
            return true;
        }
        else
        {
            Destroy(beatQueue.Dequeue());
            Debug.Log(color + " beat missed");
            return false;
        }
    }

    bool isHit()
    {
        if( (getY(beatQueue.Peek()) > -1 * trackRectTransform.rect.height) && (getY(beatQueue.Peek()) < -1 * trackRectTransform.rect.height + hitThreshold))
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
