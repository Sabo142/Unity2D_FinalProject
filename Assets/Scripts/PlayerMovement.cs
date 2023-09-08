using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int JUMP_HEIGHT = 1000;
    [SerializeField] private int FORWARD_FORCE = 10000;
    private Rigidbody2D rb;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int TagDetect;
    private Touch playerTouch;
    public Animator animator;
    void Update()
    {
        TouchMovement();
    }
    private void OnValidate()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }
    private void TouchMovement()
    {
        if (Input.touchCount > 0)
        {
            playerTouch = Input.GetTouch(0);
            if (playerTouch.phase == TouchPhase.Began)
            {
                if (TagDetect == 1)
                {
                    if (animator != null)
                    {
                        animator.Play("Base Layer.PlayerMovementAnimation");
                    }
                    spriteRenderer.flipX = true;
                    rb.AddForce(Vector2.up * JUMP_HEIGHT);
                    rb.AddForce(Vector2.right * FORWARD_FORCE);
                }
                else if (TagDetect == 2)
                {
                    if (animator != null)
                    {
                        animator.Play("Base Layer.PlayerMovementAnimation");
                    }
                    spriteRenderer.flipX = false;
                    rb.AddForce(Vector2.up * JUMP_HEIGHT);
                    rb.AddForce(Vector2.left * FORWARD_FORCE);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rb.velocity = Vector2.zero;
        if (collision.gameObject.tag == "Tree")
        {
            TagDetect = 1;
        }
        else if (collision.gameObject.tag == "Tree 2")
        {
            TagDetect = 2;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        TagDetect = 0;
    }

}
