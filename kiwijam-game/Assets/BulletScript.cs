using UnityEngine;
//Note: gameObject means the bullet that this script is attached to
public class BulletScript : MonoBehaviour
{
    public GlobalGameStateScript _globalGameState;
    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(gameObject);
            other.GetComponent<EnemyScript>().Kill();
        }
    }
}
