using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    public GameObject controller;
    public bool worked=false;
    public bool isTouched = false;
    Vector2 startPos, endPos, direction;
    float touchTimeStart, touchTimeFinish, timeInterval;

    [SerializeField]
    float throwForceInXandY = 1f;

  

    [SerializeField]
    float throwForceInZ = 250f;

    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
    }

    IEnumerator Ball()
    {
        yield return new WaitForSeconds(5);
        controller.GetComponent<GameController>().canSpawnBall = true;
    }

    // Update is called once per frame
    void Update()
    {
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
            rb.isKinematic = false;
            if (timeInterval > 0.2f)
            {
                rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);
                
            }
            isTouched = true;
        }

        if ( Input.GetMouseButtonDown(0)&& !isTouched) {
            touchTimeStart = Time.time;
            startPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) && !isTouched)
        {
            touchTimeFinish = Time.time;
            timeInterval = touchTimeFinish - touchTimeStart;
            endPos = Input.mousePosition;
            direction = startPos - endPos;
            rb.isKinematic = false;
            if (timeInterval > 0.2f)
            {
                rb.AddForce(-direction.x * throwForceInXandY, -direction.y * throwForceInXandY, throwForceInZ / timeInterval);
                rb.AddTorque(Vector3.right * throwForceInZ / timeInterval, ForceMode.Force);
            }
            isTouched = true;
        }

        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(!worked)
        {
            StartCoroutine(Ball());
            worked = true;
        }
    }
}
