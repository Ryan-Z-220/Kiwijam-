using UnityEngine;

public class SpawnEnemiesScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab

    public float spawnInterval = 2f; // Time interval between spawns
    private float spawnTimer = 0f;

    void Update()
    {
        spawnTimer += Time.deltaTime;
        //spawn enemies at random positions within a certain range
        if (spawnTimer >= spawnInterval)
        {
            spawnTimer = 0f; // Reset the timer
            int enemyCount = Random.Range(2, 7);
            for (int i = 0; i < enemyCount; i++)
            {
                SpawnEnemy();
            }
        }
    }

    public void SpawnEnemy()
    {
        Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
        //check if the spawn position is too close to the player
        bool notTooClose = false; // Flag to check if the spawn position is acceptable
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            while (notTooClose == false)
            {
                float distanceToPlayer = Vector2.Distance(spawnPosition, player.transform.position);
                if (distanceToPlayer < 4f) // If too close, find a new position
                {
                    spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
                }
                else
                {
                    notTooClose = true; // Position is acceptable
                }
            }
        }
        GameObject enemy = Instantiate(enemyPrefab as GameObject, spawnPosition, Quaternion.identity);
        enemy.GetComponent<EnemyScript>().localSpeed = Random.Range(1f, 1.5f); // Random speed between 2 and 8

    }
}
