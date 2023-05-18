using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public float score = 0;
    [SerializeField] int points;
      
   public void IncreaseScore()
    {
        score += points;      
    }

     public void queenScore()
    {
        score += points + points;      
    }

    public void DecreaseScore()
    {
        score -= points;
    }



   
    















}
