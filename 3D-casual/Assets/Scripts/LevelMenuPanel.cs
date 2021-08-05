using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMenuPanel : MonoBehaviour
{
    public bool animeTrigger;
    public Animator animator;
    private bool once = true;
    public GameObject canvasStay;
    // Update is called once per frame
    private void Start()
    {
        canvasStay = GameObject.FindGameObjectWithTag("Canvas");
        canvasStay.GetComponent<Canvas>().enabled = true;
       
        
    }
    void Update()
    {
        animeTrigger = canvasStay.GetComponent<DontDestroy>().animatorTrigger;
        if (animeTrigger && once)
        {
            
            animator.SetTrigger("end");
            once = false;
            canvasStay.GetComponent<DontDestroy>().animatorTrigger = false;
        }
    }

}
