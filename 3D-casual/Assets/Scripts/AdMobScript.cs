using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;
using System;

public class AdMobScript : MonoBehaviour
{
   
    string IntersitialAdID = "ca-app-pub-9789420081213637/2462848638";
   
    private InterstitialAd interstitial;
   

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        RequestInterstitial();
    }

   
    public void RequestInterstitial()
    {

        // Initialize an InterstitialAd.
        this.interstitial = new InterstitialAd(IntersitialAdID);
        // Called when an ad request has successfully loaded.
        this.interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        this.interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.
        this.interstitial.OnAdClosed += HandleOnAdClosed;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        this.interstitial.LoadAd(request);

       
    }

    public void LoadInterstitial()
    {
        if (this.interstitial.IsLoaded())
        {
            this.interstitial.Show();
            
        }
        else
        {
            if (gameObject.CompareTag("NextLevelButton"))
                gameObject.transform.root.GetComponent<TransitionCanvas>().NextLevelButton();
            else if (gameObject.CompareTag("LevelMenuButton"))
                gameObject.transform.root.GetComponent<TransitionCanvas>().LevelMenuButton();
        }
    }

    public void HandleOnAdLoaded(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdLoaded event received");
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
     
    }

    public void HandleOnAdOpened(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleAdOpened event received");
    }

    public void HandleOnAdClosed(object sender, EventArgs args)
    {
       
       if (gameObject.CompareTag("NextLevelButton"))
            gameObject.transform.root.GetComponent<TransitionCanvas>().NextLevelButton();
       else if (gameObject.CompareTag("LevelMenuButton"))
            gameObject.transform.root.GetComponent<TransitionCanvas>().LevelMenuButton();
        
    }

    /*
    public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleAdLeavingApplication event received");
    }
    */
}
