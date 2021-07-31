using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public bool canSpawnBall=false;
    public bool groundPlane=false;
    private GameObject activatedBall;
    private bool ok = true;

    private Vector3 ballStartPos;

    public GameObject balls;
    public GameObject[] newBall = new GameObject[10];

    public int ballCount;
   
    void Start()
    {
        ballStartPos = new Vector3(0, -5 , 10);
        SpawnBalls();
        ActivateBalls();
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

        if (canSpawnBall && ballCount > 0)
        {   
            ballCount--;
            DeactivateBalls();
            ActivateBalls();
            
        }

    }

    void LoadNewScene()
    {

        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    }

    void LoadSameScene()
    {
  
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);

    }

    /*
    void LoadBall()
    {
        canSpawnBall = false;
        newBall = Instantiate(newBall, ballStartPos, Quaternion.identity);
        newBall.GetComponent<Rigidbody>().isKinematic = true;
        newBall.GetComponent<Swipe>().isTouched = false;
        newBall.transform.position = ballStartPos;
        ballCount--;
    }
    */
    void SpawnBalls()
    {
        for(int i =0; i< ballCount; i++)
        {
            newBall[i] = Instantiate(balls, ballStartPos, Quaternion.identity);
            newBall[i].SetActive(false);
            newBall[i].transform.position = ballStartPos;
            
        }
    }

    void ActivateBalls()
    {
        activatedBall = newBall[ballCount - 1];
        activatedBall.GetComponent<Swipe>().isBallActive = true;
        activatedBall.SetActive(true);
        canSpawnBall = false;
    }

    void DeactivateBalls()
    {
        activatedBall.GetComponent<Swipe>().isBallActive = false;
    }
   
}
