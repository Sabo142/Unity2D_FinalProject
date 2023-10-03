using UnityEngine;

public class OnAppFocus : MonoBehaviour
{
    public bool IsGamePaused = false;

    void OnGUI()
    {
    if (IsGamePaused)
        {
            GUI.Label(new Rect(100, 100, 50, 30),"GAME PAUSED");
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
