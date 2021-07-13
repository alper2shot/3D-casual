using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool canSpawnBall;
    private Vector3 ballStartPos;
    public GameObject ball;
    Rigidbody ballrb;

    // Start is called before the first frame update
    void Start()
    {
        ballrb = ball.GetComponent<Rigidbody>();
        ballStartPos = ball.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawnBall)
        {
            ball.transform.position = ballStartPos;
            canSpawnBall = false;
            ballrb.isKinematic = true;
        }
    }
}
