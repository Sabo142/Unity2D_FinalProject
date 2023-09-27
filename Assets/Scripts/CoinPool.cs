using System.Collections;
using UnityEngine;
public class CoinPool : MonoBehaviour
{
    [SerializeField] Coins coinPrefab;
    private bool gameIsPaused;
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
        float randomTimeSpawn = Random.Range(4f, 8f);
        yield return new WaitForSeconds(randomTimeSpawn);
        if (!gameIsPaused)
        {
            float randomCoinPosition = Random.Range(-1.46f, 1.46f);
            Instantiate(coinPrefab, new Vector3(randomCoinPosition, 7, 0), Quaternion.identity);
        } 
        StartCoroutine(spawnCoins());


    }
    public void OnGameStateChanged(GameState gameState)
    {
        switch (gameState)
        {
            case GameState.Play:
                {
                    { 
                        gameIsPaused = false;
                    }
                    
                }break;
            case GameState.PauseMenu:
                {
                    gameIsPaused = true;
                }
                break;
            case GameState.Dead:
                {
                    gameIsPaused = true;
                }break;
        }
    }
}
