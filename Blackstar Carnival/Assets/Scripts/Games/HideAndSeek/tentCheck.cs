using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tentCheck : MonoBehaviour
{
    public GameObject tent;
    private bool isColliding;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && isColliding)
        {
                HideAndSeekGameManager.Instance.checkResults(tent);
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag.Equals("Player"))
        {
            isColliding = true;
        }
    }
}
