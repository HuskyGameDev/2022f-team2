using System;
using System.Collections;
using BlackstarCarnival.Games.CanCrasher;
using UnityEngine;

public class CanCrasherSwipeController :  MonoBehaviour
{
    public static CanCrasherSwipeController Instance;
    [SerializeField] float _throwSpeed = 10f;
    [SerializeField] float _throwSpeedZ = 10f;

    private Vector3 _direction;
    private float _throwTime;
    [HideInInspector] public GameObject Ball;

    private bool canThrow = false;
    
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        } else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if ( CanCrasherGameManager.Instance.GameState != CanCrasherGameState.Playing || Ball == null ) return;
        
        // Start swipe
        if (Input.GetMouseButtonDown(0))
        {
            _direction = Input.mousePosition;
            _throwTime = Time.time;
            canThrow = true;
        }
        
        // End swipe
        if (Input.GetMouseButtonUp(0) && canThrow)
        {
            _throwTime = Time.time - _throwTime;
            _direction = (Input.mousePosition - _direction).normalized;
            _direction.z = _throwSpeedZ / _throwTime;
            canThrow = false;
            
            // UI Handling
            CanCrasherUIManager.Instance.ShowSwipeArrow(new Vector3(0, 0, Vector2.SignedAngle(Vector2.up, _direction)));
            
            // throw the ball
            Ball.GetComponent<Rigidbody>().isKinematic = false;
            Ball.GetComponent<Rigidbody>().AddForce(_direction * _throwSpeed, ForceMode.Impulse);
            Ball = null;
            // TODO: Play ball throw sound 
        }
    }
}