using UnityEngine;

public class FlowerIcon : MonoBehaviour
{
    public Flower flower; // Reference to the flower this icon represents

    public FlowerIcon(Flower flower)
    {
        this.flower = flower;
    }

    void Start()
    {
        GetComponent<SpriteRenderer>().color = Flower.rarityColors[flower.rarity];
    }
}
