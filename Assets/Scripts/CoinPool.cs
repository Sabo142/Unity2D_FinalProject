using UnityEngine;

public class CoinPool : MonoBehaviour
{
    private int poolSize = 10;
    [SerializeField] Coins coinPrefab;
    private Coins[] coinPool;
    void Start()
    {
        coinPool = new Coins[poolSize];
        for (int i = 0; i < poolSize; i++)
        {
            coinPool[i] = Instantiate(coinPrefab);
            coinPool[i].gameObject.SetActive(true);
        }
    }  
}
