using GoogleMobileAds.Api;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RewardedADManager : MonoBehaviour
{
#if UNITY_ANDROID
    string adUnitid = "ca-app-pub-9428131507800002/5968920044";
#elif UNITY_IPHONE
    string adUnitid = "ca-app-pub-9428131507800002/5384249071";
#endif
    private RewardedAd odullureklam;
    
   [SerializeField] NeedsController can;


    void Start()
    {
        this.odullureklam = new RewardedAd(adUnitid);

        AdRequest request = new AdRequest.Builder().Build();
        this.odullureklam.LoadAd(request);
        this.odullureklam.OnUserEarnedReward += oyuncuyacanekle;

    }

    public void ReklamIzlet()
    {
        //  AdRequest request = new AdRequest.Builder().Build();
        //  this.odullureklam.LoadAd(request);

        if (this.odullureklam.IsLoaded())
        {

            this.odullureklam.Show();
    //        can.AddHealth(100);

        }
    }

    private void oyuncuyacanekle(object sender, Reward e)
    {
        can.FullEnergy(1000);
        AdRequest request = new AdRequest.Builder().Build();
        this.odullureklam.LoadAd(request);
    }
}
