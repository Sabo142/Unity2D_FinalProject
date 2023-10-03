using UnityEngine;
using TMPro;
public class OnAppFocus : MonoBehaviour
{
    public bool IsGamePaused = false;
    [SerializeField] private TextMeshProUGUI pauseText;
    private void OnApplicationFocus(bool focus)
    {
        IsGamePaused = !focus;
    }
    private void OnApplicationPause(bool pause)
    {
        IsGamePaused = pause;
        if (IsGamePaused)
        {
            pauseText.text = "GAME PAUSED";
            Debug.Log("game paused");
        }
        else
            pauseText.text = "";
    }
}