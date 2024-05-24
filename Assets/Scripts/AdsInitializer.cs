using UnityEngine;
using UnityEngine.Advertisements;
 
public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener, IUnityAdsLoadListener, IUnityAdsShowListener
{
    [SerializeField] string _androidGameId;
    [SerializeField] string _iOSGameId;
    [SerializeField] bool _testMode = true;
    [SerializeField] private string _adUnitId;
    private string _gameId;
 
    void Awake()
    {
        InitializeAds();
    }
 
    public void InitializeAds()
    {
    #if UNITY_IOS
            _gameId = _iOSGameId;
    #elif UNITY_ANDROID
            _gameId = _androidGameId;
    #elif UNITY_EDITOR
            _gameId = _androidGameId; 
    #endif
        if (!Advertisement.isInitialized && Advertisement.isSupported)
        {
            Advertisement.Initialize(_gameId, _testMode, this);
        }
    }

 
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        LoadAdd();
    }
 
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }

    public void ShowIterstialAd()
    {
        if(Advertisement.isInitialized)
        {
            Advertisement.Show(_adUnitId, this);
        }
    }

    private void LoadAdd()
    {
        if(Advertisement.isInitialized)
        {
            Advertisement.Load(_adUnitId, this);
        }
    }

    public void OnUnityAdsAdLoaded(string placementId)
    {
        Debug.Log("Unity ads loaded " + placementId);
    }

    public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
    {
        Debug.Log("Unity ads failed to load");
    }

    public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
    {
        Debug.Log("Unity ads show falilure");
    }

    public void OnUnityAdsShowStart(string placementId)
    {
        Debug.Log("Unity ads show start");
    }

    public void OnUnityAdsShowClick(string placementId)
    {
        Debug.Log("Unity ads show click");
    }

    public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
    {
        Debug.Log("Unity ads show complete");
    }

    public void DoExitGame() 
    {
        Application.Quit();
    }
}