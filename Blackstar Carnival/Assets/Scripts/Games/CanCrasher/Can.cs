using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public GameObject canGO;
    public Transform canPos;
    public int canValue;

    // Start is called before the first frame update
    
    public Can(GameObject canGO, Transform canPos, int canValue)
    {
        this.canGO = canGO;
        this.canPos = canPos;
        this.canValue = canValue;
    }
    
    void spawnCan()
    {
        Instantiate(canGO, canPos.position, canPos.rotation);
    }

    void destroyCan()
    {
        Destroy(canGO);
    }
}
