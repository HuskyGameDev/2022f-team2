using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlackstarCarnival
{
    internal sealed class MainMenu : MonoBehaviour
    {
        public void NewGame()
        {
            SceneManager.LoadScene("Carnival");
        }

        public void ExitGame()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #else
            Application.Quit();
            #endif
            Debug.Log("Game is exiting");
        }
    }
}

