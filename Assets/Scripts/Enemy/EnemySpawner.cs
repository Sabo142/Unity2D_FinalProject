using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject grasshopper;
    [SerializeField] private GameObject fly;
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
        grasshopper = Resources.Load<GameObject>("Prefab/Grasshopper");
        fly = Resources.Load<GameObject>("Prefab/Fly");
        snake = Resources.Load<GameObject>("Prefab/Snake");
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        float speed = GameManager.Instance.GameSpeed/10;

        float randomTimeSpawn = Random.Range(2f - speed, 4f - speed);
        yield return new WaitForSeconds(randomTimeSpawn);
        float randomPosition = Random.Range(0f, 2f);
        if (!gameIsPaused)
        {
            if (randomPosition == 0) { Instantiate(snake, treeLeft.transform.position, Quaternion.identity); }
            else { Instantiate(snake, treeRight.transform.position, Quaternion.identity); }
        }
        randomTimeSpawn = Random.Range(1f - speed, 4f - speed);
        yield return new WaitForSeconds(randomTimeSpawn);
        randomPosition = Random.Range(-1.46f, 1.46f);
        if (!gameIsPaused)
        {
            Instantiate(fly, new Vector3(randomPosition, 7, 0), Quaternion.identity);
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
