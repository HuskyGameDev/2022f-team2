using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CanCrasher : MonoBehaviour
{
    [System.Serializable]
    public class Cans
    {
        public string name;
        public int size;
        public GameObject can;
    }

    public List<Can> CanList;
  
    // Start is called before the first frame update
    void Start()
    {

    }

}
