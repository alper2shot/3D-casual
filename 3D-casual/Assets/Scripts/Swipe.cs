using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject controller;
    
    public bool isTouched = false;
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float mass;

    [SerializeField]
    float throwForceInXandY = 1f;

    [SerializeField]
    float restricter;

    [SerializeField]
    float restricterY;

    [SerializeField]
    float throwForceInZ = 250f;

    Rigidbody rb;

    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

   
    void FixedUpdate()
    {
        //Touch Settings

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

            if (timeInterval > 0.1f && direction.y >= restricterY)
            {
                rb.isKinematic = false;
                rb.AddForce(-direction.x * throwForceInXandY * mass, -direction.y * throwForceInXandY * mass, throwForceInZ / timeInterval * mass);
                rb.AddTorque(Vector3.right * throwForceInZ / timeInterval, ForceMode.Force);
                isTouched = true;
            }
            
        }

        //Mouse Settings

        if ( Input.GetMouseButtonDown(0)&& !isTouched) {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && !isTouched)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
           
            if(timeInterval > restricter)
            {
                timeInterval = restricter;
            }

            endPos = Input.mousePosition;
            direction = startPos - endPos;
            if (timeInterval > 0.1f && -direction.y >= restricterY)
            {
               
                rb.isKinematic = false;
                rb.AddForce(-direction.x * throwForceInXandY * mass, -direction.y * throwForceInXandY * mass, throwForceInZ / timeInterval * mass);
                rb.AddTorque(Vector3.right * throwForceInZ / timeInterval, ForceMode.Force);
                isTouched = true;
            }
        
        }

        
    }

    
    private void OnCollisionStay(Collision collision)
    {
        
        if (Input.GetMouseButtonUp(0))
        {
            controller.GetComponent<GameController>().canSpawnBall = true;
        }

    }
    
}
