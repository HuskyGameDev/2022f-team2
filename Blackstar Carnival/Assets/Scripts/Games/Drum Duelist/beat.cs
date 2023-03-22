using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    public GameObject track;
    private RectTransform trackTransform;
    private RectTransform rectTransform;
    float tempo; 
    // Start is called before the first frame update
    void Start()
    {
        trackTransform = track.GetComponent<RectTransform>();
        rectTransform = this.GetComponent<RectTransform>();
        tempo = trackTransform.rect.height / 72000;
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(0, tempo * -1, 0, trackTransform);
    }

}
