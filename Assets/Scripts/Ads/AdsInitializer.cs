using UnityEngine;
using UnityEngine.Advertisements;
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
    [SerializeField] string _androidID;
    [SerializeField] string _iosID;
    [SerializeField] bool _testmode = true;
    [SerializeField] AdsButton Adsbutton;
    private string _gameID;
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
        Debug.Log($"Unity ads initialization failed: {error.ToString()} - {message}");
    }
}