using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Flower
{

    public static readonly Dictionary<FlowerRarity, Color> rarityColors = new()
    {
        { FlowerRarity.Common, Color.white },
        { FlowerRarity.Uncommon, Color.white },
        { FlowerRarity.Rare, Color.blue },
        { FlowerRarity.Legendary, Color.red }
    };

    private GlobalGameStateScript _globalGameState;

    public FlowerRarity rarity;
    public Modifier[] modifiers;

    public bool isEquipped = false;

    public Flower()
    {
        modifiers = new Modifier[0];

        // roll rarity
        int rarityRoll = UnityEngine.Random.Range(0, 100);
        if (rarityRoll < 10)
        {
            rarity = FlowerRarity.Legendary;
        }
        else if (rarityRoll < 40)
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
    }

    public override string ToString()
    {
        return $"{rarity} with {modifiers.Length} modifiers";
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


