using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] int fallSpeed = -3;
    [SerializeField] CoinsCounter CoinsCounter;
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
        this.transform.position = this.transform.position + new Vector3(0, fallSpeed, -1) * Time.deltaTime;
        if (this.transform.position.y < -11)
        {
            Destroy(gameObject);
        }
    }
}