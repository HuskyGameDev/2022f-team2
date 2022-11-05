using UnityEngine;

namespace BlackstarCarnival.Games.CanCrasher
{
    public class CanCrasherUIManager : MonoBehaviour
    {
        public static CanCrasherUIManager Instance;
        public GameObject SwipeArrow;
        public GameObject WinPanel;
        public GameObject LosePanel;
        public GameObject MenuPanel;
        
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
            LosePanel.SetActive(true);
            WinPanel.SetActive(false);
            MenuPanel.SetActive(false);
        }

        public void ShowWinPanel()
        {
            LosePanel.SetActive(false);
            WinPanel.SetActive(true);
            MenuPanel.SetActive(false);
        }

        public void ShowMenuPanel()
        {
            LosePanel.SetActive(false);
            WinPanel.SetActive(false);
            MenuPanel.SetActive(true);
        }

        public void HideAllPanels()
        {
            LosePanel.SetActive(false);
            WinPanel.SetActive(false);
            MenuPanel.SetActive(false);
        }
    }
}