using UnityEngine;
public class Snake : MonoBehaviour
{
    [SerializeField] private float Speed = -3f;
    [SerializeField] Animator animator;
    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }
    private void Update()
    {
        float speed = Speed * GameManager.Instance.GameSpeed;
        if (GameManager.Instance.State != GameState.Play) return;
        this.transform.position = this.transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                    { animator.enabled = true; }
                break;
            case GameState.PauseMenu:
                    { animator.enabled = false; }
                break;
            case GameState.Dead:
                    { animator.enabled = false; }
                break;
        }
    }
}