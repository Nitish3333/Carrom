using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Striker : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Transform LookAtParent;
    bool CanMove;
    RaycastHit2D hit;
    Rigidbody2D rb;
    [SerializeField] float strikerSpeed;
    [SerializeField] AudioClip sfxcollide;
    [SerializeField] Transform ForcePoint;
    [SerializeField] Image TimerImage;
    Timer timerScript;
    GameManager gameManagerScript;


    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        slider.onValueChanged.AddListener(StrafeStriker);
        timerScript = FindObjectOfType<Timer>();
        gameManagerScript = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        TimerImage.fillAmount = timerScript.fillFraction;

        if(Input.GetMouseButton(0) && gameManagerScript.PlayerTurn)
        {
            hit = Physics2D.Raycast
            (Camera.main.ScreenToWorldPoint(Input.mousePosition),Vector3.forward);

            if(hit.collider)
            {
                if(hit.transform.name == "striker")
                {
                   CanMove = true;
                }

                if(CanMove)
                {
                   LookAtParent.LookAt(hit.point);
                }
                
                float temp = Vector3.Distance(transform.position,hit.point);
                LookAtParent.localScale = new Vector3(Mathf.Clamp(temp,0.5f,2.5f),
                Mathf.Clamp(temp,0.5f,2.5f),Mathf.Clamp(temp,0.5f,2.5f));            
            }  
        }

        else if(Input.GetMouseButtonUp(0) && CanMove)
        {
           rb.AddForce(new Vector3(ForcePoint.position.x - transform.position.x,
           ForcePoint.position.y - transform.position.y,0) * strikerSpeed);
           CanMove = false;
           LookAtParent.localScale = Vector3.zero;         
           Invoke("DelayTurn",6f);
        }
    }

    public void DelayTurn()
    {
        gameManagerScript.EndTurn();
        gameObject.SetActive(false);
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        AudioSource.PlayClipAtPoint(sfxcollide,Camera.main.transform.position);
    }


    public void StrafeStriker(float value)
    {
       transform.position = new Vector3(value,-1.9f,0);
    }










}
