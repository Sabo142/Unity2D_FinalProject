using UnityEngine;
public class SideWall : MonoBehaviour
{
    [SerializeField] float Speed = -3f;
    private float timeRemaining = 20f;
    private bool gameIsPaused;

    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }

    void Update()
    {
        if (gameIsPaused) return;
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            Speed *= 1.5f;
            timeRemaining += 30;
        }
        this.transform.position = this.transform.position + new Vector3(0, Speed, 0) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            this.transform.position += new Vector3(0, 22, 0);
        }
    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                {
                    { gameIsPaused = false; }

                }
                break;
            case GameState.PauseMenu:
                {
                    { gameIsPaused = true; }

                }
                break;
            case GameState.Dead:
                {
                    { gameIsPaused = true; }
                }
                break;
        }
    }

}
