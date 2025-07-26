using System.Collections.Generic;
using UnityEngine;

public class AddFlowersFromInventory : MonoBehaviour
{
    public GameObject flowerPrefab; // Prefab to instantiate for flowers

    public void Awake()
    {
        // test data flower array
        Inventory.flowers = new Flower[]
        {
            new() { rarity = FlowerRarity.Common, modifiers = new Modifier[0] },
            new() { rarity = FlowerRarity.Uncommon, modifiers = new Modifier[0] },
            new() { rarity = FlowerRarity.Rare, modifiers = new Modifier[0] },
            new() { rarity = FlowerRarity.Legendary, modifiers = new Modifier[0] }
        };


        foreach (Flower flower in Inventory.flowers)
        {
            GameObject flowerIconObject = Instantiate(flowerPrefab);
            // set as a child of the current object
            flowerIconObject.transform.SetParent(transform, false);
            FlowerIcon flowerIcon = flowerIconObject.GetComponent<FlowerIcon>();
            flowerIcon.flower = flower;
        }
    }
}
