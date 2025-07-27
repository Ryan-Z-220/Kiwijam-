using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Flower[] equippedFlowers = new Flower[0];
    public static Flower[] flowers = new Flower[0];

    public static void AddFlower(Flower flower)
    {
        flowers = flowers.Append(flower).ToArray();
    }

    public static void EquipFlower(Flower flower)
    {
        if (equippedFlowers.Length < 5) // Max 5 equipped flowers
        {
            flower.isEquipped = true;
            equippedFlowers = equippedFlowers.Append(flower).ToArray();

            Debug.Log($"Equipped flower: {flower.rarity}");
        }
        else
        {
            Debug.LogWarning("Cannot equip more than 4 flowers.");
        }
    }

    public static void UnequipFlower(Flower flower)
    {
        flower.isEquipped = false;
        equippedFlowers = equippedFlowers.Where(f => f != flower).ToArray();

        Debug.Log($"Unequipped flower: {flower.rarity}");
    }
}
