using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class levelSelect : MonoBehaviour
{
    public Dictionary<string, object> levelInfo;
    public DDGameManager gameManager;
    public GameObject mainCanvas;
    public GameObject LevelSelectUI;
    private Queue<string> level = new Queue<string>();
    private float tempoFactor;
    private bool chordMode;

    void OnEnable()
    {
        levelInfo = new Dictionary<string, object>();
        level = new Queue<string>();
        tempoFactor = 1f;
        chordMode = false;
    }


    public void Level1()
    {
        tempoFactor = 0.6f;
        chordMode = false;

        for (int i = 0; i < 80; i++) {
            int color = Random.Range(0, 4);
            addColor(color);
        }
        loadLevel();
    }

    public void Level2()
    {
        tempoFactor = 0.8f;
        chordMode = false;

        for(int i = 0; i < 30; i++)
        {
            addParadiddle();
        }
        loadLevel();
    }

    public void Level3()
    {
        tempoFactor = 1.15f;
        chordMode = false;

        for (int i = 0; i < 30; i++)
        {
            int coin = Random.Range(0, 2);
            if (coin == 0)
            {
                addParadiddle();
            }
            else
            {
                addLine();
            }
        }
        loadLevel();
    }

    public void Level4()
    {
        tempoFactor = 1.15f;
        chordMode = true;

        for (int i = 0; i < 120; i++)
        {
            int color1 = Random.Range(0, 4);
            int color2 = Random.Range(0, 4);
            while (color2 == color1)
            {
                color2 = Random.Range(0, 4);
            }
            addColor(color1);
            addColor(color2);
        }
        loadLevel();
    }

    private void addColor(int color)
    {
        switch (color)
        {
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

    private void addParadiddle()
    {
        int color1 = Random.Range(0, 4);
        int color2 = Random.Range(0, 4);
        while (color2 == color1)
        {
            color2 = Random.Range(0, 4);
        }
        addColor(color1);
        addColor(color2);
        addColor(color1);
        addColor(color1);
    }

    private void addLine()
    {
        int direction = Random.Range(0, 2);
        if (direction == 0)
        {
            addColor(0);
            addColor(1);
            addColor(2);
            addColor(3);
        }
        else
        {
            addColor(3);
            addColor(2);
            addColor(1);
            addColor(0);
        }

    }

    private void loadLevel()
    {
        levelInfo.Add("level", level);
        levelInfo.Add("tempoFactor", tempoFactor);
        levelInfo.Add("chordMode", chordMode);
        gameManager.levelInfo = levelInfo;
        mainCanvas.SetActive(true);
        LevelSelectUI.SetActive(false);
    }
}
