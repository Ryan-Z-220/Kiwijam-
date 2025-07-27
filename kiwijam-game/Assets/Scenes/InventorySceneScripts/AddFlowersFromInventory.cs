using System.Collections.Generic;
using UnityEngine;

public class AddFlowersFromInventory : MonoBehaviour
{
    public GameObject flowerPrefab; // Prefab to instantiate for flowers

    public void Awake()
    {
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
