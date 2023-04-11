using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ballController : MonoBehaviour{
    private int hitCheck = 0;
    public Image Strengthmask;
    public KeyCode hit = KeyCode.Space;
    private Transform tran;
    private Rigidbody rb;
    public GameObject ball;
    public GameObject bell;
    public AudioSource hitSound;

    // Start is called before the first frame update
    void Start()
    {
        rb = ball.GetComponent<Rigidbody>();
        resetBall();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(hit) && (hitCheck == 0)){
                HammerHitterUIManager.Instance.PauseBar();
                hitBall();

            }
    }

    void resetBall(){
            rb.useGravity = false;
            ball.transform.position = new Vector3(0f, -1.829f, 10.966f);
        }

    void hitBall(){
            GetComponent<AudioSource>().Play();
            hitCheck = 1;
            var vel = rb.velocity;
            vel.y = Strengthmask.fillAmount * 15f;
            rb.velocity = vel;
            rb.useGravity = true;
        }

    void OnCollisionEnter(Collision col){
        if(col.gameObject == bell){
            hitSound.Play();
            rb.useGravity = false;
            rb.velocity = new Vector3(0f, 0f, 0f);
            HammerHitterGameManager.Instance.SetGameState(HammerHitterGameState.Win);
        }
        else{
            rb.useGravity = false;
            rb.velocity = new Vector3(0f, 0f, 0f);
            HammerHitterGameManager.Instance.SetGameState(HammerHitterGameState.Lose);
        }
    }

}
