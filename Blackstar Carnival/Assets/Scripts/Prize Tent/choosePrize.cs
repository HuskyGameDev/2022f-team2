using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosePrize : MonoBehaviour
{
    public GameObject thisBear;
    public Renderer rend;
    private Color startColor;
    private bool isColliding;
    public GameObject prizeMenu;
    public GameObject prompt;
    public GameObject reject;
    public GameObject UI;
    public Image shown;
    public SpriteRenderer clicked;

    public bool chosen;

    void Start()
    {
        this.chosen = false;
        // sets up the menus
        prizeMenu.SetActive(false);
        prompt.SetActive(false);
        reject.SetActive(false);
        UI.SetActive(true);
        isColliding = false;

        // gets the render stuff so the mouseover does things
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    void Update()
    {
        // if the bear that this script is on was chosen and bought
        if(this.chosen && prizeMenuManager.Instance.bought)
        {
            // takes 5 star bucks from the inventory
            StarBucksManager.Instance.UpdateBucks(-5);
            this.chosen = false;
            prizeMenuManager.Instance.bought = false;
            
            // gets rid of the object
            Destroy(thisBear);
        }
    }

    // changes color when moused over
    void OnMouseEnter()
    {
        isColliding = true;
        rend.material.color = Color.gray;
    }
    void OnMouseExit()
    {
        isColliding = false;
        rend.material.color = startColor;
    }

    void OnMouseDown()
    {
        if(isColliding)
        {
            this.chosen = true;
            UI.SetActive(false);
            // makes the shown bear render the clicked bears sprite
            shown.sprite = clicked.sprite;

            // brings up the prize menu
            Debug.Log("I was selected!");
            prizeMenu.SetActive(true);
            prompt.SetActive(true);
            reject.SetActive(false);
        }
        else { this.chosen = false; }
    }

    public void notChosen()
    {
        chosen = false;
    }
}
