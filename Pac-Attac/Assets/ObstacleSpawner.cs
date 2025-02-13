using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab; 
    public float spawnInterval = 3f; 
    private float spawnTimer;

    public float spawnRangeX = 8f; 
    public float spawnRangeY = 4f;

    void Start()
    {
        spawnTimer = spawnInterval;
    }

    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnObstacle();
            spawnTimer = spawnInterval; 
        }
    }

    void SpawnObstacle()
    {
        float randomX = Random.Range(-spawnRangeX, spawnRangeX);
        float randomY = Random.Range(-spawnRangeY, spawnRangeY);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
