using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Pocket : MonoBehaviour
{
    Score scoreScript;
    [SerializeField]TextMeshProUGUI playerScore;
    [SerializeField] AudioClip sfxbuck;
    [SerializeField] AudioClip sfxstriker;
    [SerializeField] Transform startPoint;
    [SerializeField] Transform enemyStartPoint;

    void Awake()
    {
        scoreScript = FindObjectOfType<Score>();
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "buck")
        {
            scoreScript.IncreaseScore();
            AudioSource.PlayClipAtPoint(sfxbuck,Camera.main.transform.position);
            playerScore.text = scoreScript.score.ToString();
            other.gameObject.SetActive(false);
        }
        if(other.tag == "queen")
        {
            scoreScript.queenScore();
            AudioSource.PlayClipAtPoint(sfxbuck,Camera.main.transform.position);
            playerScore.text = scoreScript.score.ToString();
            other.gameObject.SetActive(false);
        }

        else if(other.tag == "striker")
        {
            AudioSource.PlayClipAtPoint(sfxstriker,Camera.main.transform.position);
            scoreScript.DecreaseScore();
            playerScore.text = scoreScript.score.ToString();
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            other.transform.position = startPoint.position;
        }
         else if(other.tag == "EnemyStriker")
        {
            AudioSource.PlayClipAtPoint(sfxstriker,Camera.main.transform.position);
            scoreScript.DecreaseScore();
            playerScore.text = scoreScript.score.ToString();
            other.attachedRigidbody.velocity = new Vector3(0,0,0);
            other.transform.position = enemyStartPoint.position;
        }
    }

    

    




}
