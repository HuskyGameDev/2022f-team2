using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayBucks : MonoBehaviour
{
    public TextMeshProUGUI starBucksText;
    
    // Update is called once per frame
    void Update()
    {
        starBucksText.text = "Star Bucks: " + StarBucksManager.Instance.starBucks;
    }
}
