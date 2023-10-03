using UnityEngine;
public class SideWall : MonoBehaviour
{
    [SerializeField] float Speed = -3f;
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
        float speed = Speed * GameManager.Instance.GameSpeed;
        this.transform.position = this.transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
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
