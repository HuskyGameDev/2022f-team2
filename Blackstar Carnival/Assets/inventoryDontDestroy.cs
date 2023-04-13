using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class inventoryDontDestroy : MonoBehaviour
{
    public static inventoryDontDestroy Instance;
    void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}
