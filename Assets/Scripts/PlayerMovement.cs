using System.Threading;
using System.Collections;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.Analytics;

public class PlayerMovement : MonoBehaviour
{

    public DeathMenu deathmenu;
    [SerializeField] private int JUMP_HEIGHT = 1000;
    [SerializeField] private int FORWARD_FORCE = 10000;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject SpriteGameObject;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private float TimeWhileSpin = 0f;
    public int TagDetect;
    private Touch playerTouch;
    public Animator animator;
    public static int CoinCount;
    private void Awake()
    {
        GameManager.StateChanged += OnStateChanged;
        SendCustomEvent();
    }
    public void SendCustomEvent()
    {

        Analytics.SendEvent("PlayerScore", true, 1, "ok");
        /*AnalyticsEvent.Custom("PlayerScore", new
        {
            Score = 100,
        });*/
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnStateChanged;
    }
    void Update()
    {
        TouchMovement();
        TimeWhileSpin += Time.deltaTime;
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
        if (Input.touchCount > 1)
        {
            playerTouch = Input.GetTouch(0);
            if (playerTouch.position.y > 1990) return;
            spriteRenderer.transform.Rotate(Vector2.right * JUMP_HEIGHT);
            animator.Play("SpinnyPanda");
            if (TimeWhileSpin < 1)
            {
                GameManager.Instance.SetGameState(GameState.Dead);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Tree")
        {
            TagDetect = 1;
            int timer = 0;
        }
        else if (collision.gameObject.tag == "Tree 2")
        {
            TagDetect = 2;
        }
        else if (collision.collider.tag == "Snake" || collision.collider.tag == "Fly" || collision.collider.tag == "Grasshopper")
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
        LeanTween.color(SpriteGameObject, Color.black, 1);
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