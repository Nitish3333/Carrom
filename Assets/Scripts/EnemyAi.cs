using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] Transform EnemyStartPoint;
    [SerializeField] Rigidbody2D StrikerBody;
    [SerializeField] float speed;
    GameManager gameManager;
    float randomNo ;
    public bool CanMove = true;
    public bool timeToStrike;
    Timer timerScript;
    [SerializeField] Image TimerImage;

    void Awake()
    {
        speed = Random.Range(600f,1500f);
        gameManager = FindObjectOfType<GameManager>();
        StrikerBody = GetComponent<Rigidbody2D>();
        randomNo =  Random.Range(-1.3f,1.3f);
        timerScript = FindObjectOfType<Timer>();
    }

    void Update()
    {
        TimerImage.fillAmount = timerScript.fillFraction;
        
        StrikerPosition();
        if(timeToStrike)
        {
           Invoke("ForceStiker",2);
           timeToStrike = false;
        }      
    }

    void ForceStiker()
    {  
        StrikerBody.AddForce(transform.position * speed);
        Invoke("DelayTurn",6f);    
    }

    public void StrikerPosition()
    {   
        if(CanMove)  
        {
          transform.position = new Vector3(randomNo,1.285f,0);
          StrikerBody.SetRotation(Random.Range(0,359));
          CanMove = false;
          timeToStrike = true;
        }
    }

    public void DelayTurn()
    {
        gameManager.StartTurn();
        CanMove = true;
    }

    public void ToggleCanMovebool()
    {
        CanMove = true;
    }


























}
