using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;

public class WatchAddButton : MonoBehaviour
{
    string RewarededAdID = "ca-app-pub-9789420081213637/7478800777";

    private RewardedAd rewardedAd;
    private int levelNo;
    private bool canClose=false;

    public void Start()
    {
        MobileAds.Initialize(initStatus => { });

        levelNo = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().levelNo;

        this.rewardedAd = new RewardedAd(RewarededAdID);

        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }

    public void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded())
        {
            canClose = true;
            this.rewardedAd.Show();
        }
        else
        {
            gameObject.transform.root.GetComponent<TransitionCanvas>().LevelMenuButton();
        }
    }

    public void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        
    }

    public void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        
    }

    public void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        //gameObject.transform.root.GetComponent<TransitionCanvas>().LevelMenuButton();
    }

    public void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        if(canClose)
        gameObject.transform.root.GetComponent<TransitionCanvas>().LevelMenuButton();
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        if (!PlayerPrefs.HasKey(levelNo.ToString()))
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>()
            .levelStars[levelNo - 1].GetComponent<LevelScore>().starCount = 3;

            PlayerPrefs.SetInt((levelNo).ToString(), 3);
        }
        else if (PlayerPrefs.GetInt(levelNo.ToString()) < 3)
        {
            GameObject.FindGameObjectWithTag("LevelManager").GetComponent<LevelManager>()
            .levelStars[levelNo - 1].GetComponent<LevelScore>().starCount = 3;

            PlayerPrefs.SetInt((levelNo).ToString(), 3);
        }

        if (levelNo < 24 && PlayerPrefs.GetInt("openTilThis") < levelNo + 1)
            PlayerPrefs.SetInt("openTilThis", levelNo + 1);

        PlayerPrefs.Save();

        GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().ActivateNextScene();
    }
}