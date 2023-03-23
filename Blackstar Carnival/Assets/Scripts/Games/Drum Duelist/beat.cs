using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{
    public GameObject track;
    public GameObject mainCanvas;
    public GameObject levelSelect;
    private RectTransform trackTransform;
    private RectTransform rectTransform;
    private Dictionary<string, object> levelInfo;

    float tempo; 
    // Start is called before the first frame update
    void Start()
    {
        trackTransform = track.GetComponent<RectTransform>();
        rectTransform = this.GetComponent<RectTransform>();
        tempo = trackTransform.rect.height / 15000;
        rectTransform.anchoredPosition = new Vector3(0, 0, 0);
        levelInfo = levelSelect.GetComponent<levelSelect>().levelInfo;
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(0, tempo * -1 * (float)levelInfo["tempoFactor"], 0, mainCanvas.transform);
    }

}
