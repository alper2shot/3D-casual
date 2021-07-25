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
        canSpawnBall = false;
        groundPlane = false;
        ok = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }

    void LoadSameScene()
    {
        canSpawnBall = false;
        groundPlane = false;
        ok = true;
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
     
    }

    void Update()
    {
        if (groundPlane && ok)
        {
            ok = false;
            LoadNewScene();
            
        }

        if(ballCount == 0 && !groundPlane)
        {
            //Game Over and Ads

        
            LoadSameScene();
        }


        if (canSpawnBall && ballCount >0)
        {
            ballrb.isKinematic = true;
            ball.transform.position = ballStartPos;
            canSpawnBall = false;
            ballCount--;
            ball.GetComponent<Swipe>().isTouched = false;
        }

        
    }
}
