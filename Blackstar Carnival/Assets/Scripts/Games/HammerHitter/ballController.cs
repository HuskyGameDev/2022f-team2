using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour{
    private int hitCheck = 0;
    public Image Strengthmask;
    public KeyCode hit = KeyCode.Space;
    private Transform tran;
    private Rigidbody2D rb;
    public GameObject ball;
    public GameObject bell;
    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody2D>();
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(hit) && (hitCheck == 0)){
                hitBall();
            }
    }

    void resetBall(){
            rb.gravityScale = 0;
            ball.transform.position = new Vector3(0f, -3f, 10f);
        }

    void hitBall(){
            hitCheck = 1;
            var vel = rb.velocity;
            vel.y = Strengthmask.fillAmount * 10f;
            rb.velocity = vel;
            rb.gravityScale = .5f;
        }

    void OnCollisionEnter2D(Collision2D col){
        Debug.Log("FFF");
        if(col.gameObject == bell){
            Debug.Log("FFF");
            GetComponent<AudioSource>().Play();
            rb.velocity = new Vector3(0f, 0f, 0f);
        }
    }

}
