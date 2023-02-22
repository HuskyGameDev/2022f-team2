using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode()]

public class StrengthBar : MonoBehaviour
{
    public float max;
    public float current;
    public Image mask;

    // Start is called before the first frame update
    void Start()
    {
           resetBar();
    }

    // Update is called once per frame
    void Update()
    {
        current = current + .02f;
        GetCurrentFill();
    }

    void resetBar(){
        max = 100f;
        current = 0f;
        mask.fillAmount = 0f;
    }

    void GetCurrentFill(){
        float fillAmount = (float)current / (float) max;
        mask.fillAmount = fillAmount;
    }

}
