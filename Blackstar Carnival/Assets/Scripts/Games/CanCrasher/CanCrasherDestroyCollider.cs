using System;
using BlackstarCarnival.Games.CanCrasher;
using UnityEngine;

public class CanCrasherDestroyCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                CanCrasherStageManager.Instance.SpawnBall();
                
                break;
            case "Can":
                CanCrasherStageManager.Instance.CanDestroyed();
                break;
        } 
        Destroy(collision.gameObject);
    }
}