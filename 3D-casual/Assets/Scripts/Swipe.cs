using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject controller;

    private int hitCount=0;
    private bool canHit = true;

    public bool isBallActive = false;
    public bool isTouched = false;
    private bool once = true;
    Vector3 startPos, endPos, direction, myVectorEnd, myVectorStart;
    
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float mass;

    [SerializeField]
    float throwForceInX;

    [SerializeField]
    float throwForceInY;

    [SerializeField]
    float restricter;

    [SerializeField]
    float restricter2;

    [SerializeField]
    float restricterY;

    [SerializeField]
    float throwForceInZ;

    Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.GetComponent<SphereCollider>().enabled = false;

    }

    void GiveForce()
    {
        rb.GetComponent<SphereCollider>().enabled = true;
        startPos.x = 0f;
        startPos.y = -15f;
        direction = startPos - endPos;
        rb.isKinematic = false;
        rb.AddForce(-direction.x * throwForceInX * mass, -direction.y * throwForceInY * mass, throwForceInZ / timeInterval * mass);
        rb.AddTorque(Vector3.right * throwForceInZ / timeInterval, ForceMode.Force);
        isTouched = true;
    }

   
    void Update()
    {
        //Touch Settings

        /*
        if(Input.touchCount > 0 && !isTouched && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            touchTimeStart = Time.time;
            startPos = Input.GetTouch(0).position;
        }

        if (Input.touchCount > 0 && !isTouched && Input.GetTouch(0).phase == TouchPhase.Ended)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.GetTouch(0).position;
            direction = startPos - endPos;


            if (timeInterval > restricter)
            {
                timeInterval = restricter;
            }

            if (-direction.y >= restricterY)
            {
                GiveForce();
            }
            
        }
        */
        //Mouse Settings


        if (BallPositioner.isIn)
        {
            //transform.Rotate(Input.mousePosition.y * Time.deltaTime / 2, 0f, 0.0f, Space.Self);
           
            transform.LookAt(new Vector3((Input.mousePosition.x / 23 - 15),  Input.mousePosition.y/10, 40f));
           
        } 

        if (isBallActive && !controller.GetComponent<GameController>().starPanel.activeInHierarchy)
        {
            

            if (Input.GetMouseButtonDown(0) && !isTouched)
            {
                touchTimeStart = Time.time;
                myVectorStart = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f);
                startPos = Camera.main.ScreenToWorldPoint(myVectorStart);


            }

            if (Input.GetMouseButtonUp(0) && !isTouched && BallPositioner.isIn)
            {
                touchTimeFinish = Time.time;
                timeInterval = touchTimeFinish - touchTimeStart;
                myVectorEnd = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 40f);
                endPos = Camera.main.ScreenToWorldPoint(myVectorEnd);
                direction = startPos - endPos;

                BallPositioner.MakeFalse();

                if (timeInterval > restricter)
                {
                    timeInterval = restricter;
                }

                if(timeInterval < restricter2)
                {
                    timeInterval = restricter2;
                }

                if (-direction.y > restricterY)
                {

                    GiveForce();
                    AudioManagerScript.PlaySound(AudioManagerScript.Sound.swipe);
                }

            }
        }


    }

    IEnumerator BallHit()
    {
        canHit = false;
        yield return new WaitForSeconds(0.2f);
        canHit = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (canHit && rb.velocity.magnitude >= 5)
        {
            
            if (collision.gameObject.CompareTag("Wooden"))
            {
                if(rb.velocity.magnitude <= 15)
                AudioManagerScript.PlaySound(AudioManagerScript.Sound.wooden2, transform.position, 0.05f * rb.velocity.magnitude);
                else
                    AudioManagerScript.PlaySound(AudioManagerScript.Sound.wooden, transform.position, 0.05f * rb.velocity.magnitude);
            }
            
            else
            AudioManagerScript.PlaySound(AudioManagerScript.Sound.ballHit, transform.position, 0.015f * rb.velocity.magnitude);
            //hitCount++;
            StartCoroutine(BallHit());

        }
        
        if (once && isBallActive)
        {
            gameObject.GetComponent<TrailRenderer>().emitting = false;
            controller.GetComponent<GameController>().canSpawnBall = true;
            once = false;
        }
    }

    public void OnBecameInvisible()
    {
        gameObject.SetActive(false);
        if (once)
        {
            gameObject.GetComponent<TrailRenderer>().emitting = false;
            if(controller != null)
            controller.GetComponent<GameController>().canSpawnBall = true;
            once = false;
        }
        
    }
}
