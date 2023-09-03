using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private int JUMP_HEIGHT = 1000;
    [SerializeField] private int FORWARD_FORCE = 10000;
    private Rigidbody2D rigidbody;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public int TagDetect;
    private Touch playerTouch;
    void Update()
    {
        TouchMovement();
    }
    private void OnValidate()
    {
        rigidbody = GetComponent<Rigidbody2D>();
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
                    spriteRenderer.flipX = true;
                    rigidbody.AddForce(Vector2.up * JUMP_HEIGHT * Time.deltaTime);
                    rigidbody.AddForce(Vector2.right * FORWARD_FORCE * Time.deltaTime);
                }
                else if (TagDetect == 2)
                {
                    spriteRenderer.flipX = false;
                    rigidbody.AddForce(Vector2.up * JUMP_HEIGHT * Time.deltaTime);
                    rigidbody.AddForce(Vector2.left * FORWARD_FORCE * Time.deltaTime);
                }
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody.velocity = Vector2.zero;
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
