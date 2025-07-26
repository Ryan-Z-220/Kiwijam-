using UnityEngine;

public class EnemyScript : MonoBehaviour
{

    public float speed = 3f; // Speed at which the enemy moves towards the player
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

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
        }

    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            //destroy the player and the enemy
            Destroy(other.gameObject); // Destroy the player
            Destroy(gameObject); // Destroy the enemy
            Debug.Log("Player hit by enemy! Game Over.");
        }
    }
}
