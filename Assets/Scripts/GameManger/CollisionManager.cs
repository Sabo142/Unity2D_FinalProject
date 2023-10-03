using UnityEngine;
public class CollisionManager : MonoBehaviour
{
    public AudioClip collisionSound;
    private void OnCollisionEnter2D(Collision2D collision) // for enemies
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision) // for coin
    {
        if (collision.gameObject.tag == "Player")
        {
            AudioSource.PlayClipAtPoint(collisionSound, transform.position);
        }
    }
}