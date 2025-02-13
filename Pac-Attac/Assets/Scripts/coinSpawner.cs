using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coinSpawner : MonoBehaviour
{
    public GameObject coinPrefab;
    public float spawnInterval = 3f;
    public float spawnPadding = 50f;

    private float spawnTimer;

    // I'm making the coins spawn on the screen
    void Start()
    {
        spawnTimer = spawnInterval;
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer -= Time.deltaTime;

        if (spawnTimer <= 0f)
        {
            SpawnCoin();
            spawnTimer = spawnInterval;
        }
    }

    void SpawnCoin()
    {
        Vector2 screenMin = Camera.main.ScreenToWorldPoint(new Vector2(spawnPadding, spawnPadding));
        Vector2 screenMax = Camera.main.ScreenToWorldPoint(new Vector2(1024 - spawnPadding, 1024 - spawnPadding));
        float randomX = Random.Range(screenMin.x, screenMax.x);
        float randomY = Random.Range(screenMin.y, screenMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);
        Instantiate(coinPrefab, spawnPosition, Quaternion.identity);
    }
}
