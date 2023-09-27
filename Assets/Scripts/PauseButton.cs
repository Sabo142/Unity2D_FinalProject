using UnityEngine;
using UnityEngine.UI;

public class PauseButton : MonoBehaviour
{

    [SerializeField] private Image image;
    [SerializeField] private Sprite pauseSprite;
    [SerializeField] private Sprite resumeSprite;
    [SerializeField] private bool gameIsPaused = false;
    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChange;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChange;
    }
    public void buttonPresed()
    {
        if (!gameIsPaused) 
        {
            StartPause();
            gameIsPaused = true;
        }
        else
        {
            StopPause();
            gameIsPaused = false;
        }
    }
    private void StartPause()
    {
        image.sprite = resumeSprite;
        GameManager.Instance.SetGameState(GameState.PauseMenu);
    }
    private void StopPause()
    {
        image.sprite = pauseSprite;
        GameManager.Instance.SetGameState(GameState.Play);
    }
    private void OnGameStateChange(GameState state)
    {
        switch (state)
        {
            case GameState.Dead:
                {
                    gameObject.SetActive(false);

                }
                break;



        }
    }
}
