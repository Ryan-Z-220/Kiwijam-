using System.Linq;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public static Flower[] flowers;

    public void Awake()
    {
        flowers = new Flower[0];
    }

    public static void AddFlower(Flower flower)
    {
        flowers = flowers.Append(flower).ToArray();
    }
}
