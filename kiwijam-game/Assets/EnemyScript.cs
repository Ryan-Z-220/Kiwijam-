using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public AudioClip explosionSound; // Sound effect for explosion
    public GameObject explosionPrefab; // Prefab for explosion effect

    public AudioClip deathSound; // Sound to play when the player dies

    public GameObject flowerPrefab; // Prefab for flower to drop when the enemy is killed



    private GlobalGameStateScript _globalGameState;
    public float speed = 3f; // Speed at which the enemy moves towards the player
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
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);

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
        GameObject flower = Instantiate(flowerPrefab, transform.position, Quaternion.identity);

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //destroy the player and the enemy
            Destroy(other.gameObject); // Destroy the player
            Destroy(gameObject); // Destroy the enemy
            Debug.Log("Player hit by enemy! Game Over.");
            _globalGameState.GameOver();
            Time.timeScale = 0;
            // Play death sound
            AudioSource.PlayClipAtPoint(deathSound, transform.position);
        }
    }
}
