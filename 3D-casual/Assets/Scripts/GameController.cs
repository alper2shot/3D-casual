using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    public bool canSpawnBall=false;
    public bool groundPlane=false;
    private bool ok = true;

    public float threeStarScore, twoStarScore;

    private int starCount=0;
    public int ballCount;
    public int levelNo;

    private Vector3 ballStartPos;

    private GameObject activatedBall;
    public GameObject balls;
    public GameObject[] newBall = new GameObject[10];
    public GameObject pauseButton;

    public Animator animator;
    
   
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
            CalculateSuccess();
            ActivateNextScene();

            ok = false;
            //LoadNewScene();

            StartCoroutine(LoadLevelMenu());
            
        }

        if(ballCount == 0)
        {
            //CalculateSuccess();
            //Game Over and Ads
            //LoadSameScene();
            StartCoroutine(LoadLevelMenu());
        }

        if (canSpawnBall && ballCount > 0)
        {   
            ballCount--;
            DeactivateBalls();
            ActivateBalls();
            
        }

    }

    IEnumerator LoadLevelMenu()
    {
        pauseButton.SetActive(false);
        animator.SetTrigger("end");        
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene(1);

    }

    IEnumerator LoadNewScene()
    {
        //animator.SetTrigger("");
        yield return new WaitForSeconds(1.5f);
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

    void CalculateSuccess()
    {
        if(ballCount >= threeStarScore)
        {
            starCount = 3;
        }
        else if(ballCount < threeStarScore && ballCount >= twoStarScore && starCount != 3)
        {
            starCount = 2;
        }
        else if(ballCount < twoStarScore && starCount < 1)
        {
            starCount = 1;
        }

        GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>()
            .levelStars[levelNo-1].GetComponent<LevelScore>().starCount = starCount;

       
    }

    void ActivateNextScene()
    {
        if (GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>()
            .levelStars[levelNo] != null && starCount != 0)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>()
            .levelStars[levelNo].GetComponent<LevelScore>().isLevelActive = true;
        }
    }
   
}
