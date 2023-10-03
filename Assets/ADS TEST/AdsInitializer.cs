
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidID;
    [SerializeField] string _iosID;
    [SerializeField] bool _testmode = true;
    private string _gameID;
    [SerializeField] AdsButton Adsbutton;
    void Awake()
    {
        InitializeAds();
    }

    public void InitializeAds()
    {
        _gameID = (Application.platform == RuntimePlatform.IPhonePlayer)
            ? _iosID : _androidID;
        Advertisement.Initialize(_gameID, _testmode, this);
    }

    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete");
        Adsbutton.LoadAd();
    }

    public void OnInitializationFailed(UnityAdsInitializationError error,  string message)
    {
        Debug.Log($"unity ads initialization failed: {error.ToString()} - {message}");
    }
}
