using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class playAgain : MonoBehaviour
{
    public Button play;

    // Start is called before the first frame update
    void Start()
    {
        play.onClick.AddListener(task);
    }
    public void task()
    {
        SceneManager.LoadScene("Hide And Seek");
    }
}
