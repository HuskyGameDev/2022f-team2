using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Exit : MonoBehaviour
{
    public Button quit;

    // Start is called before the first frame update
    void Start()
    {
        quit.onClick.AddListener(task);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void task()
    {
        SceneManager.LoadScene("Carnival");
    }

}
