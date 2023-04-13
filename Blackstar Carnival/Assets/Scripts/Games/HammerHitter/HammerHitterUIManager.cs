using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HammerHitterUIManager : MonoBehaviour
{
    public static HammerHitterUIManager Instance;
    public GameObject StrengthBar; public Image Strengthmask; public float currentStrength; public float maxStrength; public int reverse = 0;
    public GameObject LosePanel;
    public GameObject WinPanel;
    private int playCheck = 0;

    public GameObject pause;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resetStrengthBar();
    }

    // Update is called once per frame
    void Update()
    {
        if(pause.activeInHierarchy == false) { GetCurrentFill(); }
    }

    void resetStrengthBar(){
        maxStrength = 100f;
        currentStrength = 0f;
        Strengthmask.fillAmount = 0f;
    }

    void GetCurrentFill(){
        if(playCheck == 0){
            if(currentStrength>=100f){
                reverse = 1;
            }
            if(currentStrength<=0f){
                reverse = 0;
            }
            if(reverse == 0){
                currentStrength = currentStrength + .3f;
                float fillAmount = (float)currentStrength / (float) maxStrength;
                Strengthmask.fillAmount = fillAmount;
            }
            if(reverse == 1){
                currentStrength = currentStrength - .3f;
                float fillAmount = (float)currentStrength / (float) maxStrength;
                Strengthmask.fillAmount = fillAmount;
            }

        }
    }

    public void ShowLosePanel(){
        StrengthBar.SetActive(false);
        LosePanel.SetActive(true);
        WinPanel.SetActive(false);
    }

    public void ShowWinPanel(){
        StrengthBar.SetActive(false);
        LosePanel.SetActive(false);
        WinPanel.SetActive(true);
    }

    public void ShowPlayingPanel(){
        StrengthBar.SetActive(true);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    public void ShowMenuPanel(){
        StrengthBar.SetActive(false);
        LosePanel.SetActive(false);
        WinPanel.SetActive(false);
    }

    public void PauseBar(){
        playCheck=1;
    }

    public void playAgain()
    {
        SceneManager.LoadScene("Hammer Hitter");
    }
}
