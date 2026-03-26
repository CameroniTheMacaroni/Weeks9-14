using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
//using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIBitsScript : MonoBehaviour
{
    public TextMeshProUGUI timerTxt;
    public TextMeshProUGUI scoreTxt;

    public float timer = 3f;
    public int score;

    public float roundedTimer;
    public float initialTimer = 5f;

    public int targetColorValue;
    public Image targetColor;

    public bool timerPaused;

    public TileSpawnerScript tilespawnerscript;
    void Start()
    {
       changeTargetColor();
    }

    
    void Update()
    {
        scoreTxt.text = score.ToString();

        roundedTimer = (float)Math.Round(timer, 1);//round the timer value to one decimal place
        timerTxt.text = roundedTimer.ToString();//set the UI text to the timer
        if (timer <= 0)//if timer is done, reset
        {
            timer = initialTimer;
            timerPaused = true;
            tilespawnerscript.tilesRoundOver();
        }
        else if (timerPaused == false) 
        {
            timer -= Time.deltaTime;//tick tock
        }
    }
    public void changeTargetColor()
    {
        targetColorValue = Random.Range(1, 7);

        switch (targetColorValue)
        {
            case 1:
                targetColor.color = Color.red;
                break;
            case 2:
                targetColor.color = Color.blue;
                break;
            case 3:
                targetColor.color = Color.yellow;
                break;
            case 4:
                targetColor.color = Color.green;
                break;
            case 5:
                targetColor.color = Color.orange;
                break;
            case 6:
                targetColor.color = Color.purple;
                break;
        }
    }
}