using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    private Queue<string> level;
    public DDGameManager gameManager;
    public GameObject mainCanvas;
    public GameObject LevelSelectUI;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Level1()
    {
        level = new Queue<string>();

        for (int i = 0; i < 50; i++) {
            int color = Random.Range(0, 4);
            switch (color) {
                case 0:
                    level.Enqueue("red");
                    break;
                case 1:
                    level.Enqueue("blue");
                    break;
                case 2:
                    level.Enqueue("green");
                    break;
                case 3:
                    level.Enqueue("yellow");
                    break;
            }
        }
        gameManager.level = level;
        mainCanvas.SetActive(true);
        LevelSelectUI.SetActive(false);
    }

}
