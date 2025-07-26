using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject explosionPrefab; // Prefab for explosion effect
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<Rigidbody2D>().linearVelocity = transform.up * 10f;

        // set direction to the nearest enemy to the bullet
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length > 0)
        {
            GameObject nearestEnemy = enemies[0];
            float nearestDistance = Vector2.Distance(transform.position, nearestEnemy.transform.position);
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestEnemy = enemy;
                    nearestDistance = distance;
                }
            }
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().linearVelocity = direction * 10f;
        }
        else
        {
            Destroy(gameObject);
        }


        Destroy(gameObject, 4f);


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


        }


    }
}