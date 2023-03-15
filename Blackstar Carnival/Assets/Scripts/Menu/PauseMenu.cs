using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public Button pause;
    public Button controls;
    public Button quit;
    public Button resume;
    public GameObject pauseMenu;
    public GameObject controlMenu;

    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(pauseFunc);
        controls.onClick.AddListener(controlsFunc);
        quit.onClick.AddListener(quitFunc);
        resume.onClick.AddListener(resumeFunc);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) && controlMenu.activeInHierarchy == true)
        {
            controlMenu.SetActive(false);
        }
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == true)
        {
            pauseMenu.SetActive(false);
        }
    }
    public void pauseFunc()
    {
        // displays the pause panel
        pauseMenu.SetActive(true);
        controlMenu.SetActive(false);
    }
    public void controlsFunc()
    {
        // pull up controls?
        controlMenu.SetActive(true);
    }
    public void quitFunc()
    {
        SceneManager.LoadScene("Main Menu");
    }
    public void resumeFunc()
    {
        // hide the menu
        pauseMenu.SetActive(false);
    }
}
