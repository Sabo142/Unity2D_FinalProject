using UnityEngine;
public class Grasshopper : MonoBehaviour
{
    [SerializeField] private float Speed = -2.5f;
    [SerializeField] private int FORWARD_FORCE = 100;
    [SerializeField] Animator animator;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int TagDetect;
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
        Hopping();
        if (GameManager.Instance.State != GameState.Play) return;
        float speed = Speed * GameManager.Instance.GameSpeed;
        this.transform.position = this.transform.position + new Vector3(0, speed, 0) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
    private void Hopping()
    {
        if (TagDetect == 1)
        {
            spriteRenderer.flipY = true;
            rb.AddForce(Vector2.right * FORWARD_FORCE);
        }
        else if (TagDetect == 2)
        {
            spriteRenderer.flipY = false;
            rb.AddForce(Vector2.left * FORWARD_FORCE);
        }
        TagDetect = 0;
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