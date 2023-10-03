using UnityEngine;

public class Fly : MonoBehaviour
{
    public float flySpeed = -3f;
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
            flySpeed *= 50;
            timeRemaining += 20;
        }
        this.transform.position = this.transform.position + new Vector3(0, flySpeed, 0) * Time.deltaTime;
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