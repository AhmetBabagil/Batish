using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SnakeRewardedBoost : MonoBehaviour
{
#if UNITY_ANDROID
    string adUnitid = "ca-app-pub-9428131507800002/5968920044";
#elif UNITY_IPHONE
    string adUnitid = "ca-app-pub-9428131507800002/5384249071";
#endif
    private RewardedAd odullureklam;
    
   [SerializeField] SnakeSnake snake;


    void Start()
    {
        this.odullureklam = new RewardedAd(adUnitid);

        AdRequest request = new AdRequest.Builder().Build();
        this.odullureklam.LoadAd(request);
        this.odullureklam.OnUserEarnedReward += oyuncuyacanekle;

    }

    public void ReklamIzlet()
    {


        if (this.odullureklam.IsLoaded())
        {

            this.odullureklam.Show();

        }
    }

    private void oyuncuyacanekle(object sender, Reward e)
    {
        snake.isBoostActive = true;
        AdRequest request = new AdRequest.Builder().Build();
        this.odullureklam.LoadAd(request);
    }
}
