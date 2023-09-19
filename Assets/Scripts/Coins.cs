using UnityEngine;

public class Coins : MonoBehaviour
{
    [SerializeField] CoinsCounter CoinsCounter;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            CoinsCounter.addCoin(1);
            gameObject.SetActive(false);
        }
    }
}