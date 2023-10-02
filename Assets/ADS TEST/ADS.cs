using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class ADS : MonoBehaviour
{
    public string myGameIdAndroid = "5433131";
    public string myGameIdIOS = "5433130";
    public string adUnitIdAndroid = "Interstitial_Android";
    public string adUnitIdIOS = "Interstitial_iOS";
    public string myAdUnitId;
    public bool adStarted;
    private bool testMode = true;
    void Start()
    {
#if UNITY_ANDROID
    Advertisement.Initialize(myGameIdAndroid, testMode);
	myAdUnitId = adUnitIdAndroid;
#else
        Advertisement.Initialize(myGameIdIOS, testMode);
        myAdUnitId = adUnitIdIOS;
#endif
    }

    void Update()
    {
        if (Advertisement.isInitialized && !adStarted)
        {
            Advertisement.Load(myAdUnitId);
            Advertisement.Show(myAdUnitId);
            adStarted = true;
        }
    }
}
