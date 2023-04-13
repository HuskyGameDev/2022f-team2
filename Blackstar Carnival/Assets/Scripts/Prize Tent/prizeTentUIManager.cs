using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class prizeTentUIManager : MonoBehaviour
{
    public void ExitTent()
    {
        SceneManager.LoadScene("Carnival");
    }
}
