using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enableCheck : MonoBehaviour
{
    // when the menu is brought back up
    void OnEnable()
    {
        prizeMenuManager.Instance.bought = false;
    }
}
