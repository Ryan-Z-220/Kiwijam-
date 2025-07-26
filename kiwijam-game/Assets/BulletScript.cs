using UnityEngine;
//Note: gameObject means the bullet that this script is attached to
public class BulletScript : MonoBehaviour
{
    public AudioClip explosionSound; // Sound effect for explosion
    public GameObject explosionPrefab; // Prefab for explosion effect
    public GlobalGameStateScript _globalGameState;
    // Start is called once before the first execution of Update after the MonoBehaviour is created




    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            // Destroy the bullet and the enemy
            Destroy(other.gameObject);
            Destroy(gameObject);
            // Instantiate explosion effect
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // Destroy explosion effect after 1 second
            Destroy(explosion, 1f);
            _globalGameState.ChangeScore(10); // Increment player score by 10
            AudioSource.PlayClipAtPoint(explosionSound, transform.position);
        }
    }
}
