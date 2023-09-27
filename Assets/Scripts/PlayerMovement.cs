using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public DeathMenu deathmenu;
    [SerializeField] private int JUMP_HEIGHT = 1000;
    [SerializeField] private int FORWARD_FORCE = 10000;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int TagDetect;
    private Touch playerTouch;
    public Animator animator;
    public static int CoinCount;
    private void Awake()
    {
        GameManager.StateChanged += OnStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnStateChanged;
    }
    void Update()
    {
        TouchMovement();
    }
    private void TouchMovement()
    {
        if (GameManager.Instance.State != GameState.Play) return;
        if (Input.touchCount > 0)
        {
            playerTouch = Input.GetTouch(0);
            if (playerTouch.position.y > 1990) return;
            if (playerTouch.phase == TouchPhase.Began)
            {
                if (TagDetect == 1)
                {

                    animator.Play("Rest");

                    spriteRenderer.flipX = true;
                    rb.AddForce(Vector2.up * JUMP_HEIGHT);
                    rb.AddForce(Vector2.right * FORWARD_FORCE);
                }
                else if (TagDetect == 2)
                {

                    animator.Play("Rest");

                    spriteRenderer.flipX = false;
                    rb.AddForce(Vector2.up * JUMP_HEIGHT);
                    rb.AddForce(Vector2.left * FORWARD_FORCE);
                }
            }
            TagDetect = 0;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            TagDetect = 1;
        }
        else if (collision.gameObject.tag == "Tree 2")
        {
            TagDetect = 2;
        }
        else if (collision.collider.tag == "Snake")
        {
            GameManager.Instance.SetGameState(GameState.Dead);
        }
    }
    void OnStateChanged(GameState gameState)
    {
        Debug.Log(gameState.ToString());
        switch (gameState)
        {
            case GameState.Dead:
                {
                    Death();
                    break;
                }
            case GameState.Play:
                {
                    Play(); break;
                }
            case GameState.PauseMenu:
                {
                    animator.enabled = false;
                    break;
                }

        }
        
    }

    void Death()
    {
        if (animator != null) 
            animator.enabled = false;
        if (rb != null) 
        {
            rb.gravityScale = 1.0f;
            rb.freezeRotation = false;
            rb.MoveRotation(Random.Range(-90, 90));
        }
        if (deathmenu != null) 
        {
            deathmenu.ToggleDeathMenu();
        };
        
    }
    void Play()
    {
        if (animator != null)
            animator.enabled = true;
        if (rb != null) 
        {
            rb.gravityScale = 0f;
            rb.freezeRotation = true;
        }
    }
}
