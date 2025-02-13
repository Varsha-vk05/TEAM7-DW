using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public float spawnInterval = 3f;
    private float spawnTimer;

    public float spawnPadding = 220f; 

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
        
        Vector2 screenMin = Camera.main.ScreenToWorldPoint(new Vector2(spawnPadding, spawnPadding));
        Vector2 screenMax = Camera.main.ScreenToWorldPoint(new Vector2(1024 - spawnPadding, 1024 - spawnPadding));

    
        float randomX = Random.Range(screenMin.x, screenMax.x);
        float randomY = Random.Range(screenMin.y, screenMax.y);
        Vector2 spawnPosition = new Vector2(randomX, randomY);

       
        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
    }
}
