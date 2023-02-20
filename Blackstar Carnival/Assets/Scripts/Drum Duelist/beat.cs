using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class beat : MonoBehaviour
{

    private RectTransform rectTransform;
    int tempo = 100;
    // Start is called before the first frame update
    void Start()
    {
        rectTransform = this.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector3(0, 250, 0);
    }

    // Update is called once per frame
    void Update()
    {
        rectTransform.Translate(0, (float)-1 / tempo, 0);
    }
}
