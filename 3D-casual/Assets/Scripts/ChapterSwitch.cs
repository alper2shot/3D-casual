using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChapterSwitch : MonoBehaviour
{
  
    public void ChapterChange()
    {
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<DontDestroy>().chapter2.SetActive(true);
        GameObject.FindGameObjectWithTag("Canvas").GetComponent<DontDestroy>().chapter1.SetActive(false);
        

    }
        
    
}
