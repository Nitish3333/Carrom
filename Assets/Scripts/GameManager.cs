using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject GameOverUI;
    public bool PlayerTurn = true;
    public GameObject enemyStriker;
    public GameObject Striker;
    public Transform strikerStartingPt;
  

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
    }

    public void EndTurn()
    {
        PlayerTurn = false;
        enemyStriker.SetActive(true);
    }

    public void StartTurn()
    {
        PlayerTurn = true;
        enemyStriker.SetActive(false);
        Striker.SetActive(true);
        Striker.transform.position = strikerStartingPt.position;
    }









}
