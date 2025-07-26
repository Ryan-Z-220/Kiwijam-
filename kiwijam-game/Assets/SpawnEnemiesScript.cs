using UnityEngine;

public class SpawnEnemiesScript : MonoBehaviour
{
    public GameObject enemyPrefab; // Reference to the enemy prefab
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //spawn enemies at random positions within a certain range
        if (Time.time % 2f < 0.01f) // Spawn every 2 seconds
        {
            Vector2 spawnPosition = new Vector2(Random.Range(-8f, 8f), Random.Range(-4f, 4f));
            GameObject enemy = Instantiate(enemyPrefab as GameObject, spawnPosition, Quaternion.identity);
            enemy.GetComponent<EnemyScript>().speed = Random.Range(1f, 5f); // Random speed between 1 and 5
        }
    }
}
