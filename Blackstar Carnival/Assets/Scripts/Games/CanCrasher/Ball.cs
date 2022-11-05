using System;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private Transform _spawnPoint;
    private float scale;

    private void Awake()
    {
        _spawnPoint = GameObject.Find("BallSpawnPoint").transform;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Can"))
        {
            // TODO: Play ball hit can effect
        }
    }

    void FixedUpdate()
    {
        var minDistance = 0f;
        var maxDistance = 15f;
 
        var minScale = 0.6f;
        var maxScale = 1.2f;
 
        scale = Mathf.Lerp(maxScale, minScale, Mathf.InverseLerp(minDistance, maxDistance, transform.position.z - _spawnPoint.position.z));
        transform.localScale = new Vector3(scale, scale, scale);
    }
}