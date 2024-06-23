using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using GoogleMobileAds.Common;

public class ADManager : MonoBehaviour
{
    private BannerView bannerView;
    private InterstitialAd Interstitial;

    bool reklamgosterildi = false;

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
           this.BannerRequest();
        this.InterStitialRequest();


    }

    public void GecisReklamiGoster()
    {




        if (reklamgosterildi == false && PlayerPrefs.GetInt("removeads")!=1)
        {
            if (this.Interstitial.IsLoaded())
            {
                this.Interstitial.Show();
                reklamgosterildi = true;
                Invoke("LoadNewAd", 5f);
            }

        }

    }

    public void LoadNewAd()
    {
        AdRequest request = new AdRequest.Builder().Build();
        this.Interstitial.LoadAd(request);
        reklamgosterildi = false;
    }
    void BannerRequest()
    {
        #if UNITY_ANDROID
        string bannerreklamid = "ca-app-pub-9428131507800002/8209796346";//banner lost samurai android
#elif UNITY_IPHONE
string bannerreklamid ="ca-app-pub-9428131507800002/5200489628";
#endif
        this.bannerView = new BannerView(bannerreklamid, AdSize.Banner, AdPosition.Top);
        AdRequest request = new AdRequest.Builder().Build();
        this.bannerView.LoadAd(request);
    }

    void InterStitialRequest()
    {
#if UNITY_ANDROID
        string gecisreklamid = "ca-app-pub-9428131507800002/3534328398";//geçiþ reklamý, ölünce yap
#elif UNITY_IPHONE
        string gecisreklamid = "ca-app-pub-9428131507800002/9323494083";//geçiþ reklamý, ölünce yap
#endif

        this.Interstitial = new InterstitialAd(gecisreklamid);
        AdRequest request = new AdRequest.Builder().Build();
        this.Interstitial.LoadAd(request);
    }
}
