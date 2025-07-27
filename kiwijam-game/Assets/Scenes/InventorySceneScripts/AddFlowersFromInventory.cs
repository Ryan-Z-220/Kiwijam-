using System.Collections.Generic;
using UnityEngine;

public class AddFlowersFromInventory : MonoBehaviour
{
    public GameObject flowerPrefab; // Prefab to instantiate for flowers

    public void Awake()
    {
        foreach (Flower flower in Inventory.flowers)
        {
            GameObject flowerIconObject = Instantiate(flowerPrefab, transform);
            FlowerIcon flowerIcon = flowerIconObject.GetComponent<FlowerIcon>();
            flowerIcon.flower = flower;
        }
    }
}
