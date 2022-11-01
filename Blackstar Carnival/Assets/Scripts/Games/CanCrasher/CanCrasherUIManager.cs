using UnityEngine;

namespace BlackstarCarnival.Games.CanCrasher
{
    public class CanCrasherUIManager : MonoBehaviour
    {
        public static CanCrasherUIManager Instance;
        public GameObject SwipeArrow;
        
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
    }
}