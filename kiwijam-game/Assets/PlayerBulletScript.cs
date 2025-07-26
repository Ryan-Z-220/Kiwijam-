using UnityEngine;

public class PlayerBulletScript : MonoBehaviour
{

    public GameObject bulletPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //spawn a bullet prefab at the player's position every 0.2 seconds without checking for input
        if (Time.time % 0.2f < 0.01f)
        {
            GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
        }
    }
}

