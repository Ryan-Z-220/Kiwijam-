using UnityEngine;
using UnityEngine.EventSystems;

public class FlowerIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Flower flower;

    public FlowerIcon(Flower flower)
    {
        this.flower = flower;
    }

    void Start()
    {
        // change the icon's color based on the flower's rarity
        var image = GetComponent<UnityEngine.UI.Image>();
        image.color = Flower.rarityColors[flower.rarity];
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            if (flower.isEquipped)
            {
                Inventory.UnequipFlower(flower);
            }
            else
            {
                Inventory.EquipFlower(flower);
            }
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        TooltipManager.Instance.SetAndShowTooltip(flower);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        TooltipManager.Instance.HideTooltip();
    }
}
