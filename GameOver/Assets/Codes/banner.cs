using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;

public class banner : MonoBehaviour
{
    // https://github.com/onatcipli/unity_AdMob/blob/master/Assets/AdMobManager.cs

    private BannerView _bannerAd;
    private string _appId = "ca-app-pub-8644394833467014~3621834051";
    private string _bannerAdId = "ca-app-pub-8644394833467014/1764174518";

    private void Start()
    {
        MobileAds.Initialize(_appId);
        requestBannerAd();
    }


    void requestBannerAd()
    {
        _bannerAd = new BannerView(_bannerAdId, AdSize.Banner, AdPosition.Bottom);
        // burada banner reklamımızın AdMobdan yüklüyoruz ve göstermek için hazır hale getiriyoruz gibi düşünebilirsiniz.
        AdRequest adRequest = new AdRequest.Builder()
        .AddTestDevice(AdRequest.TestDeviceSimulator)
        .AddTestDevice(SystemInfo.deviceUniqueIdentifier)
        .Build();

        _bannerAd.LoadAd(adRequest);
        _bannerAd.Show();
    }


    private void Update()
    {

    }


}