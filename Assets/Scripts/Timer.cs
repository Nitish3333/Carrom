using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] float timeToPlay = 120f;
    public float timerValue = 120f;
    public float fillFraction;
    GameManager gameManagerScript;

    void Awake()
    {
        gameManagerScript = FindObjectOfType<GameManager>();
    }
    
    void Update()
    {
        UpdateTimer();
    }

    private void UpdateTimer()
    {
        
          timerValue -= Time.deltaTime;
          if (timerValue > 0)
          {
           fillFraction = timerValue/timeToPlay; 
          } 

          else if(timerValue <= 0)
          {
            Debug.Log("game Over");
            gameManagerScript.GameOver();
          }
        
    }

















}
