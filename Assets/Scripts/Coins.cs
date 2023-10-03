using UnityEngine;

public class Coins : MonoBehaviour
{
    int Speed = -3;
    [SerializeField] CoinsCounter CoinsCounter;
    [SerializeField] Animator animator;
    public float timeRemaining = 20f;
    private void Start()
    {
        CoinsCounter = GameObject.Find("HUD").GetComponent<CoinsCounter>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinsCounter.addCoin(1);
            Destroy(gameObject);
        }
    }
    private void Update()
    {

        if (GameManager.Instance.State != GameState.Play) { animator.enabled = false; }
        else { animator.enabled = true; }
        if (GameManager.Instance.State != GameState.Play) return;
        float speed = Speed * GameManager.Instance.GameSpeed;
        this.transform.position = this.transform.position + new Vector3(0, speed, -1) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
}