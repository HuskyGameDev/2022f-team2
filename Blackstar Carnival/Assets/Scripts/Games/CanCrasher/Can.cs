using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    public GameObject Texture;
    
    private void FixedUpdate()
    {
        // Fix texture rotation to face camera with rotating z.
        Texture.transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z);
    }
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("Ball"))
        {
            this.GetComponent<AudioSource>().Play();
        }
    }
}
