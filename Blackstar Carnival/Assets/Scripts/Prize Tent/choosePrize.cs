using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class choosePrize : MonoBehaviour
{
    public Renderer rend;
    private Color startColor;
    private bool isColliding;
    public GameObject prizeMenu;
    public GameObject prompt;
    public GameObject reject;
    public GameObject UI;
    public Image shown;
    public SpriteRenderer clicked;

    void Start()
    {
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
            UI.SetActive(false);
            // makes the shown bear render the cliked bears sprite
            shown.sprite = clicked.sprite;

            // brings up the prize menu
            Debug.Log("I was selected!");
            prizeMenu.SetActive(true);
            prompt.SetActive(true);
            reject.SetActive(false);
        }
    }
}
