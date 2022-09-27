using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomSpawner : MonoBehaviour
{
    [SerializeField]
    public GameObject enemyPrefabs;

    [SerializeField] 
    private float spawnInterval = 4.0f;
    
    void Start()
    {
        StartCoroutine(spawnEnemy(spawnInterval, enemyPrefabs));
    }

    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds(interval);      // Silly random settings to spawn at random points
        GameObject newEnemy = Instantiate(enemy, new Vector3(Random.Range(-5f, 5), Random.Range(-6f, 6f), 0),
            Quaternion.identity);

        StartCoroutine(spawnEnemy(interval, enemy));
    }

}
