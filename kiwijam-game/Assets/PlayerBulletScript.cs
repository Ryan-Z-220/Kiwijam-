using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{

    public GameObject bulletPrefab;

    float fireTimer = 0f;
    public float fireRate = 0.2f; // Time in seconds between bullet fires



    // Update is called once per frame
    void Update()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        if (enemies.Length == 0) return;

        fireTimer += Time.deltaTime;

        //spawn a bullet prefab at the player's position every 0.2 seconds without checking for input
        if (fireTimer >= fireRate)
        {
            fireTimer = 0;

            //    find the nearest enemy
            GameObject nearestEnemy = null;
            float nearestDistance = Mathf.Infinity;
            foreach (GameObject enemy in enemies)
            {
                float distance = Vector2.Distance(transform.position, enemy.transform.position);
                if (distance < nearestDistance)
                {
                    nearestDistance = distance;
                    nearestEnemy = enemy;
                }
            }

            // bullet direction towards the nearest enemy
            Vector2 direction = (nearestEnemy.transform.position - transform.position).normalized;
            // instantiate the bullet prefab at the player's position with the direction towards the nearest enemy
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            // set the bullet's rotation to face the nearest enemy
            bullet.transform.up = direction;
            // set the bullet's speed
            bullet.GetComponent<Rigidbody2D>().linearVelocity = direction * 10f; // Speed of the bullet
        }

    }
}

