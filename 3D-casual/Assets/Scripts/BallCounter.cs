using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BallCounter : MonoBehaviour
{
    public GameObject gameController;
    public Text ballText;
    private int ballCount;

    private void Update()
    {
        ballCount = gameController.GetComponent<GameController>().ballCount;
        ballText.text = "x" + ballCount;
    }
}
