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


    // Update is called once per frame
    void Update()
    {
        // check if the bullet is colliding with an enemy using physics2d
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, 0.1f);
        if (hit.collider != null && hit.collider.CompareTag("Enemy"))
        {
            // Destroy the bullet and the enemy
            Destroy(hit.collider.gameObject);
            Destroy(gameObject);
            // Instantiate explosion effect
            GameObject explosion = Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            // destroy explosion effect after 1 second
            Destroy(explosion, 1f);

            _globalGameState.ChangeScore(10); // Increment player score by 10

            AudioSource.PlayClipAtPoint(explosionSound, transform.position);

        }


    }
}
