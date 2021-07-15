using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canSpawnBall;
    private Vector3 ballStartPos;
    public GameObject ball;
    Rigidbody ballrb;
    public int ballCount;

    // Start is called before the first frame update
    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
        ballStartPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(ballCount == 0)
        {
            Destroy(ball, 4f);
        }

        if (canSpawnBall && ballCount >0)
        {
            ball.transform.position = ballStartPos;
            canSpawnBall = false;
            ballCount--;
            ballrb.isKinematic = true;
            ball.GetComponent<Swipe>().worked = false;
            ball.GetComponent<Swipe>().isTouched = false;
        }

        
    }
}
