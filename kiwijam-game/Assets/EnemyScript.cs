using System;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioClip explosionSound; // Sound effect for explosion
    public GameObject explosionPrefab; // Prefab for explosion effect

    public AudioClip deathSound; // Sound to play when the player dies

    public AudioClip hitSound; // Sound to play when the enemy is hit

    public GameObject flowerPrefab; // Prefab for flower to drop when the enemy is killed

    public static int flowerDropChance = 30; // Chance to drop a flower (in percentage)

    private GlobalGameStateScript _globalGameState;
    public static float speed = 3f; // Speed at which the enemy moves towards the player
    public float localSpeed = 1f; // Local speed for this enemy instance
    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
    }

    // Update is called once per frame
    void Update()
    {
        //make the enemy move towards the player
        GameObject player = GameObject.FindWithTag("Player");
        if (player != null)
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * localSpeed * Time.deltaTime);

            // Optionally, rotate the enemy to face the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90)); // Adjust for sprite orientation
        }

    }

    public void Kill()
    {
        Destroy(gameObject);
        GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
        Destroy(explosion, 1f);
        _globalGameState.ChangeScore(10); // Increment player score by 10
        AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        // Check if a flower should be dropped
        if (UnityEngine.Random.Range(0, 100) < flowerDropChance)
        {
            GameObject flower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (GameObject.FindWithTag("PlayerStats").GetComponent<PlayerStatsScript>().temporarilyInvincible)
            {
                return; // Ignore collision if player is temporarily invincible
            }
            Destroy(gameObject); // Destroy the enemy

            //find playerStatsScript and decrease bonus health by one
            GameObject playerStatsObject = GameObject.FindWithTag("PlayerStats");
            PlayerStatsScript playerStats = playerStatsObject?.GetComponent<PlayerStatsScript>();
            if (playerStats != null)
            {
                playerStats.bonusHealth--;
            }

            if (playerStats.bonusHealth == -1)
            {
                //destroy the player and the enemy
                Destroy(other.gameObject); // Destroy the player
                Debug.Log("Player hit by enemy! Game Over.");
                _globalGameState.GameOver();
                Time.timeScale = 0;
                // Play death sound
                AudioSource.PlayClipAtPoint(deathSound, transform.position);
            }
            else
            {
                playerStats.temporarilyInvincible = true; // Set player to temporarily invincible
                Debug.Log("Player hit by enemy! Bonus health remaining: " + playerStats.bonusHealth);
                AudioSource.PlayClipAtPoint(hitSound, transform.position);
                // make the player flash red for 0.5 seconds
                SpriteRenderer playerSprite = other.GetComponent<SpriteRenderer>();
                playerStats.StartCoroutine(playerStats.FlashRedAndReset(playerSprite));
            }
        }
    }
}
