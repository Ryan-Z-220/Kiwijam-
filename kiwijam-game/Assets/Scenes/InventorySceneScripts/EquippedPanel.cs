using UnityEngine;

public class EquippedPanel : MonoBehaviour
{
    public GameObject flowerPrefab;

    public void UpdatePanel()
    {
        // Clear existing icons
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }


        var equipped = Inventory.equippedFlowers;

        foreach (Flower flower in equipped)
        {
            GameObject flowerIconObject = Instantiate(flowerPrefab);
            // set as a child of the current object
            flowerIconObject.transform.SetParent(transform, false);
            FlowerIcon flowerIcon = flowerIconObject.GetComponent<FlowerIcon>();
            flowerIcon.flower = flower;
        }
    }
}
