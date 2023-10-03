using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class OnAppFocus : MonoBehaviour
{
    public bool IsGamePaused = false;
    [SerializeField] private TextMeshProUGUI pauseText;
    void OnGUI()
    {
        if (IsGamePaused)
        {
          pauseText.text = "GAME PAUSED";
        }
    }
    private void OnApplicationFocus(bool focus)
    {
        IsGamePaused = !focus;
    }
    private void OnApplicationPause(bool pause)
    {
        IsGamePaused = pause;
    }
}
