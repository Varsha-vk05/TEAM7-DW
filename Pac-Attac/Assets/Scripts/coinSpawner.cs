using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    public GameObject Coin; 
    public float spawnInterval = 3.5f; // Time in seconds between spawns
    public float spawnPadding = 220f; // Keeps coins from spawning at the edges

    private float spawnTimer; 

    void Start()
    {
        spawnTimer = spawnInterval; 
    }

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

        
        Instantiate(Coin, spawnPosition, Quaternion.identity);
    }
}
