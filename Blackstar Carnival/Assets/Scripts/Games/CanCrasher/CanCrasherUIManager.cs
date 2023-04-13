using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BlackstarCarnival.Games.CanCrasher
{
    public class CanCrasherUIManager : MonoBehaviour
    {
        public static CanCrasherUIManager Instance;
        public GameObject SwipeArrow;
        public GameObject WinPanel;
        public GameObject LosePanel;
        public GameObject MenuPanel;
        public GameObject CansLeftPanel;
        public GameObject BallsLeftPanel;
        
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
        
        public void ShowSwipeArrow(Vector3 eulerAngle)
        {
            SwipeArrow.SetActive(true);
            SwipeArrow.transform.eulerAngles = eulerAngle;
        }
        
        public void HideSwipeArrow()
        {
            SwipeArrow.SetActive(false);
        }

        public void ShowLosePanel()
        {
            BallsLeftPanel.SetActive(false);
            CansLeftPanel.SetActive(false);
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
            //MenuPanel.SetActive(false);
        }

        public void ShowWinPanel()
        {
            BallsLeftPanel.SetActive(false);
            CansLeftPanel.SetActive(false);
            LosePanel.SetActive(false);
            WinPanel.SetActive(true);
            //MenuPanel.SetActive(false);
        }

        public void ShowMenuPanel()
        {
            BallsLeftPanel.SetActive(false);
            CansLeftPanel.SetActive(false);
            LosePanel.SetActive(false);
            WinPanel.SetActive(false);
            //MenuPanel.SetActive(true);
        }

        public void ShowPlayingPanel()
        {
            BallsLeftPanel.SetActive(true);
            CansLeftPanel.SetActive(true);
            LosePanel.SetActive(false);
            WinPanel.SetActive(false);
            //MenuPanel.SetActive(false);
        }
        
        public void UpdateCansLeft(int cansLeft)
        {
            CansLeftPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = cansLeft.ToString();
        }
        
        public void UpdateBallsLeft(int ballsLeft)
        {
            BallsLeftPanel.transform.GetChild(0).GetComponent<TextMeshProUGUI>().text = ballsLeft.ToString();
        }

        public void playAgain()
        {
            SceneManager.LoadScene("Can Crashers");
        }
    }
}