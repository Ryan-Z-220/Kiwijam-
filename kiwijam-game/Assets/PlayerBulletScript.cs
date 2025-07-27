using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{

    public GameObject bulletPrefab;

    float fireTimer = 0f;
    public float fireRate = 0.2f; // Time in seconds between bullet fires

    void Awake()
    {
        fireRate *= FindObjectOfType<PlayerStatsScript>().firingRateMultiplier; // Adjust fire rate based on player stats
    }


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

            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
            Vector2 dir = nearestEnemy.transform.position - bullet.transform.position;
            bullet.transform.up = dir.normalized;

            bullet.GetComponent<Rigidbody2D>().linearVelocity = dir.normalized * 10f * FindObjectOfType<PlayerStatsScript>().bulletSpeedMultiplier;

            Destroy(bullet, 2f); // Destroy the bullet after 2 seconds
        }

    }
}

