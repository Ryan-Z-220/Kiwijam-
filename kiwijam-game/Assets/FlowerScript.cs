using System;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public enum FlowerRarity
{
    Common,
    Uncommon,
    Rare,
    Legendary
}

public enum Modifiers
{
    movement_speed,
    bullet_speed,
    firing_rate,
    health,
    damage,
    score,
    flower_drop_rate,
}

public class Modifier
{
    public Modifiers modifierType;
    public float value;

    public Modifier(Modifiers modifierType, float value)
    {
        this.modifierType = modifierType;
        this.value = value;
    }

    public override string ToString()
    {
        return $"{value * 100}% increased {Modifiers.GetName(typeof(Modifiers), modifierType)}";
    }

}


public class FlowerScript : MonoBehaviour
{
    private GlobalGameStateScript _globalGameState;

    public FlowerRarity rarity;
    public Modifier[] modifiers;

    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();

        // roll rarity
        int rarityRoll = UnityEngine.Random.Range(0, 100);
        if (rarityRoll < 5)
        {
            rarity = FlowerRarity.Legendary;
        }
        else if (rarityRoll < 20)
        {
            rarity = FlowerRarity.Rare;
        }
        else if (rarityRoll < 50)
        {
            rarity = FlowerRarity.Uncommon;
        }
        else
        {
            rarity = FlowerRarity.Common;
        }

        // roll modifiers based on rarity
        int modifierCount = rarity switch
        {
            FlowerRarity.Common => 1,
            FlowerRarity.Uncommon => 2,
            FlowerRarity.Rare => 3,
            FlowerRarity.Legendary => 4,
            _ => throw new ArgumentOutOfRangeException()
        };

        for (int i = 0; i < modifierCount; i++)
        {
            Modifiers modifierType = (Modifiers)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Modifiers)).Length);
            // Ensure the modifier is not already added
            while (modifiers != null && modifiers.Any(m => m.modifierType == modifierType))
            {
                modifierType = (Modifiers)UnityEngine.Random.Range(0, Enum.GetValues(typeof(Modifiers)).Length);
            }
            float value = UnityEngine.Random.Range(1, 30) / 100f; // Random value between 1 and 30
            Modifier newModifier = new Modifier(modifierType, value);
            modifiers = modifiers.Append(newModifier).ToArray();
        }


        // Log the flower's rarity and modifiers
        Debug.Log($"Flower Rarity: {rarity}");

        foreach (var modifier in modifiers)
        {
            Debug.Log(modifier.ToString());
        }
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
