using UnityEngine;

public class FlowerScript : MonoBehaviour
{

    private GlobalGameStateScript _globalGameState;

    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            // Logic for when the player collects the flower
            Debug.Log("Flower collected!");
            Destroy(gameObject); // Destroy the flower after collection

            _globalGameState.ChangeScore(5); // Increment player score by 5
        }
    }
}
