using System.Collections;
using UnityEngine;
public class CoinPool : MonoBehaviour
{
    [SerializeField] Coins coinPrefab;
    public void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    public void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }
    private void Start()
    {
        StartCoroutine(spawnCoins());
    }
    IEnumerator spawnCoins()
    {
        int randomTimeSpawn = Random.Range(4, 8);
        float randomCoinPosition = Random.Range(-1.46f, 1.46f);
        Instantiate(coinPrefab, new Vector3(randomCoinPosition, 7, 0), Quaternion.identity);
        yield return new WaitForSeconds(randomTimeSpawn);
        StartCoroutine(spawnCoins());
        
    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                {
                    { StartCoroutine(spawnCoins()); }
                    
                }
                break;
                case GameState.Dead:
                {
                    StopCoroutine(spawnCoins());
                }break;
        }
    }
}
