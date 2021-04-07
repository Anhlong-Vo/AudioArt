﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public AudioSource music;

    public bool startPlaying;

    public Spawner spawner;

    public static GameManager instance;

    public int currentScore;
    public int scorePerNote = 100;

    public int currentMultiplier;
    public int multiplierTracker;
    public int[] multiplierThresholds;

    public Text scoreText;
    public Text multiplierText;



    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        scoreText.text = "Score: 0";
        currentMultiplier = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!startPlaying)
        {
            if (spawner.isActiveAndEnabled)
            {
                startPlaying = true;

                music.Play() ;
            }
        }
    }
    public void NoteHit()
    {
        Debug.Log("Note Hit");

        if (currentMultiplier - 1 < multiplierThresholds.Length)
        {
            multiplierTracker++;
            if (multiplierThresholds[currentMultiplier - 1] <= multiplierTracker)
            {
                multiplierTracker = 0;
                currentMultiplier++;
            }

        }
        currentScore += scorePerNote * currentMultiplier;
        scoreText.text = "Score: " + currentScore;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }

    public void NoteMissed()
    {
        Debug.Log("Missed");
        currentMultiplier = 1;
        multiplierTracker = 0;
        multiplierText.text = "Multiplier: x" + currentMultiplier;
    }
}