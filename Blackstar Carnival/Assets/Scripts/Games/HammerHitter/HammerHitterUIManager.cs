using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace BlackstarCarnival.Games.HammerHitter{
    public class HammerHitterUIManager : MonoBehaviour
    {

        public Image Strengthmask; public float currentStrength; public float maxStrength;

        // Start is called before the first frame update
        void Start()
        {
            resetStrengthBar();
        }

        // Update is called once per frame
        void Update()
        {
            
            GetCurrentFill();
        }

        void resetStrengthBar(){
            maxStrength = 100f;
            currentStrength = 0f;
            Strengthmask.fillAmount = 0f;
        }

        void GetCurrentFill(){
            if(currentStrength>100f){
                currentStrength = 0f;
            }
            currentStrength = currentStrength + .1f;
            float fillAmount = (float)currentStrength / (float) maxStrength;
            Strengthmask.fillAmount = fillAmount;
        }
    }
}