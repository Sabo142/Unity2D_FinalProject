using UnityEngine;

public class Grasshopper : MonoBehaviour
{
    private float fallSpeed = -3f;
    [SerializeField] Animator animator;
    private float timeRemaining = 20f;
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
        if (GameManager.Instance.State != GameState.Play) return;
        timeRemaining -= Time.deltaTime;
        if (timeRemaining <= 0)
        {
            fallSpeed *= 2;
            timeRemaining += 20;
        }
        this.transform.position = this.transform.position + new Vector3(0, fallSpeed, 0) * Time.deltaTime;
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
                {
                    {
                        animator.enabled = true;
                    }

                }
                break;
            case GameState.PauseMenu:
                {
                    {
                        animator.enabled = false;
                    }

                }
                break;
            case GameState.Dead:
                {
                    {
                        animator.enabled = false;
                    }
                }
                break;
        }
    }
}
