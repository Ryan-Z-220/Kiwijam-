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
        // Update tooltip position to follow the mouse with a slight offset
        transform.position = Input.mousePosition + new Vector3(-10, 20, 0);
    }

    public void SetAndShowTooltip(Flower flower)
    {
        gameObject.SetActive(true); // Show the tooltip manager

        Modifier[] modifiers = flower.modifiers;
        FlowerRarity rarity = flower.rarity;
        Color color = Flower.rarityColors[rarity];


        // make new tooltip TMPs for each modifier
        foreach (Modifier modifier in modifiers)
        {
            GameObject tooltip = Instantiate(tooltipPrefab, transform);
            Tooltip tooltipComponent = tooltip.GetComponent<Tooltip>();
            tooltipComponent.SetTooltip(modifier.ToString(), Color.white);
        }
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
