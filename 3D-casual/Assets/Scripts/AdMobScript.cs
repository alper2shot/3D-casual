using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class AdMobScript : MonoBehaviour
{
    string appID = "ca-app-pub-9789420081213637~9306642947";

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { }); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
