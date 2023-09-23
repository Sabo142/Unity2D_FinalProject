using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject snake;
    [SerializeField] private GameObject treeLeft;
    [SerializeField] private GameObject treeRight;
    private void Start()
    {
        StartCoroutine(spawnEnemy());
    }
    IEnumerator spawnEnemy()
    {
        int randomTimeSpawn = Random.Range(2, 5);
        int randomPosition = Random.Range(0, 2);
        if(randomPosition == 0) { Instantiate(snake,treeLeft.transform.position, Quaternion.identity);}
        else { Instantiate(snake,treeRight.transform.position, Quaternion.identity);}
        
        yield return new WaitForSeconds(randomTimeSpawn);
        StartCoroutine(spawnEnemy());

    }


}
