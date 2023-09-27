using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject treeLeft;
    [SerializeField] private GameObject treeRight;
    private bool gameIsPaused;

    private void Awake()
    {
        GameManager.StateChanged += OnGameStateChanged;
    }
    private void OnDestroy()
    {
        GameManager.StateChanged -= OnGameStateChanged;
    }

    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {        
        float randomTimeSpawn = Random.Range(2f, 5f);
        yield return new WaitForSeconds(randomTimeSpawn);
        int randomPosition = Random.Range(0, 2);
        if (!gameIsPaused)
        {
            if (randomPosition == 0) { Instantiate(snake, treeLeft.transform.position, Quaternion.identity); }
            else { Instantiate(snake, treeRight.transform.position, Quaternion.identity); }
        }
            
        StartCoroutine(spawnEnemy()); 
        

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

                }
                break;
            case GameState.PauseMenu:
                {
                    { gameIsPaused = true; }

                }
                break;
            case GameState.Dead:
                {
                    { gameIsPaused = true; }
                }
                break;
        }
    }

}
