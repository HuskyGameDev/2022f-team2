using System;
using System.Collections;
using BlackstarCarnival.Games.CanCrasher;
using UnityEngine;

public class CanCrasherDestroyCollider : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Ball":
                StartCoroutine(SpawnBallAfterSeconds(2));
                break;
            case "Can":
                CanCrasherStageManager.Instance.CanDestroyed();
                break;
        } 
        Destroy(collision.gameObject);
    }

    IEnumerator SpawnBallAfterSeconds(int seconds)
    {
        yield return new WaitForSeconds(seconds);
        CanCrasherStageManager.Instance.SpawnBall();
    }
}