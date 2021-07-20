using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool canSpawnBall=false;
    public bool groundPlane=false;
    private bool ok = true;

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

    void LoadNewScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

   

    // Update is called once per frame
    void Update()
    {
        if (groundPlane && ok)
        {
            
            LoadNewScene();
            ok = false;
        }

        if(ballCount == 0 && !groundPlane)
        {
            //Game Over and Ads

            Destroy(ball, 4f);
            LoadNewScene();
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
