using UnityEngine;

public class TooltipManager : MonoBehaviour
{
    public static TooltipManager Instance;

    public GameObject tooltipPrefab; // Prefab for the tooltip UI

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

    void Start()
    {
        Cursor.visible = true; // Ensure the cursor is visible
        gameObject.SetActive(false); // Hide the tooltip manager by default
    }

    void Update()
    {
        transform.position = Input.mousePosition; // Update tooltip position to follow the mouse
    }

    public void SetAndShowTooltip(Flower flower)
    {
        gameObject.SetActive(true); // Show the tooltip manager

        Modifier[] modifiers = flower.modifiers;
        FlowerRarity rarity = flower.rarity;
        Color color = Flower.rarityColors[rarity];

        string message = $"Rarity: {rarity}\nModifiers: {string.Join(", ", System.Linq.Enumerable.Select(modifiers, m => m.ToString()))}";

        Debug.Log($"Setting tooltip with message: {message} and color: {color}");
    }

    public void HideTooltip()
    {
        gameObject.SetActive(false);

        foreach (Transform child in transform)
        {
            Destroy(child.gameObject); // Destroy all child tooltips
        }
    }
}
