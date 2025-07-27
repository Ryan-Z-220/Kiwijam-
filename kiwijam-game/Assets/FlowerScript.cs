using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FlowerObject : MonoBehaviour
{

    public Flower flower;

    private GlobalGameStateScript _globalGameState;

    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
        flower = new Flower();

        // set the color of the flower based on rarity
        GetComponent<SpriteRenderer>().color = Flower.rarityColors[flower.rarity];

        if (UnityEngine.Random.Range(0, 100) < 50) // 50% chance to flip the flower sprite
        {
            //flip the flower sprite on x axis
            Vector3 scale = transform.localScale;
            scale.x *= -1; // Flip the x scale
            transform.localScale = scale;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the flower after collection

            Inventory.AddFlower(this.flower); // Add the flower to the player's inventory

            _globalGameState.ChangeScore(5); // Increment player score by 5
        }
    }
}
