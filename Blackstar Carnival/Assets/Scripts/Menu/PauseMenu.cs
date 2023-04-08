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
    public Button back;
    public GameObject pauseMenu;
    public GameObject controlMenu;
    public string scene;

    // Start is called before the first frame update
    void Start()
    {
        pause.onClick.AddListener(pauseFunc);
        controls.onClick.AddListener(controlsFunc);
        quit.onClick.AddListener(quitFunc);
        resume.onClick.AddListener(resumeFunc);
        back.onClick.AddListener(backFunc);
    }
    void Update()
    {
        scene = SceneManager.GetActiveScene().name;
        // pauses game if not paused
        if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == false)
        {
            pauseFunc();
        }
        // gets rid of control menu if its up
        else if(Input.GetKeyDown(KeyCode.Escape) && controlMenu.activeInHierarchy == true)
        {
            controlMenu.SetActive(false);
        }
        // unpauses if paused
        else if(Input.GetKeyDown(KeyCode.Escape) && pauseMenu.activeInHierarchy == true)
        {
            resumeFunc();
        }
    }
    public void pauseFunc()
    {
        Time.timeScale = 0;
        if(scene == "Can Crashers") { CanCrasherGameManager.Instance.SetGameState(CanCrasherGameState.Menu); }
        if(scene == "Hammer Hitter") { HammerHitterGameManager.Instance.SetGameState(HammerHitterGameState.Menu); }
        
        // displays the pause panel
        pauseMenu.SetActive(true);
        controlMenu.SetActive(false);
    }
    public void controlsFunc()
    {
        controlMenu.SetActive(true);
    }
    public void quitFunc()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("Main Menu");
    }
    public void resumeFunc()
    {
        Time.timeScale = 1;
        if(scene == "Can Crashers") { CanCrasherGameManager.Instance.SetGameState(CanCrasherGameState.Playing); }
        if(scene == "Hammer Hitter") { HammerHitterGameManager.Instance.SetGameState(HammerHitterGameState.Playing); }
        // hide the menu
        pauseMenu.SetActive(false);
    }
    public void backFunc() // takes you back to the carnival
    {
        Time.timeScale = 1;
        pauseMenu.SetActive(false);
        SceneManager.LoadScene("Carnival");
    }
}
