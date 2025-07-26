using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flower : MonoBehaviour
{

    public static readonly Dictionary<FlowerRarity, Color> rarityColors = new()
    {
        { FlowerRarity.Common, Color.white },
        { FlowerRarity.Uncommon, Color.green },
        { FlowerRarity.Rare, Color.blue },
        { FlowerRarity.Legendary, Color.yellow }
    };

    private GlobalGameStateScript _globalGameState;

    public FlowerRarity rarity;
    public Modifier[] modifiers;

    void Awake()
    {
        _globalGameState = FindObjectOfType<GlobalGameStateScript>();
        modifiers = new Modifier[0];

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

        // set the color of the flower based on rarity
        GetComponent<SpriteRenderer>().color = rarityColors[rarity];

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
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject); // Destroy the flower after collection

            Inventory.AddFlower(this); // Add the flower to the player's inventory

            _globalGameState.ChangeScore(5); // Increment player score by 5
        }
    }
}


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


