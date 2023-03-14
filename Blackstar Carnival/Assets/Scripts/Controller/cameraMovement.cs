using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    public Transform followTransform;
    public BoxCollider2D topBound;
    public BoxCollider2D bottomBound;
    public BoxCollider2D leftBound;
    public BoxCollider2D rightBound;

    private float xMin, xMax, yMin, yMax;
    private float camY,camX;
    private float camOrthsize;
    private float cameraRatio;
    private Camera mainCam;

    private void Start()
    {
        xMin = leftBound.bounds.max.x;
        xMax = rightBound.bounds.min.x;
        yMin = bottomBound.bounds.min.y;
        yMax = topBound.bounds.max.y;
        mainCam = GetComponent<Camera>();
        camOrthsize = mainCam.orthographicSize;
        cameraRatio = (xMax + camOrthsize) / 2.0f;
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        camY = Mathf.Clamp(followTransform.position.y, yMin + camOrthsize, yMax - camOrthsize);
        camX = Mathf.Clamp(followTransform.position.x, xMin + cameraRatio, xMax - cameraRatio);
        this.transform.position = new Vector3(camX, camY, this.transform.position.z);
    }
}
