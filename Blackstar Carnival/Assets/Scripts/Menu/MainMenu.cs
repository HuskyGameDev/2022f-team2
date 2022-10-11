using UnityEngine;

namespace BlackstarCarnival
{
    internal sealed class MainMenu : MonoBehaviour
    {
        public void NewGame()
        {
            throw new System.NotImplementedException();
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

