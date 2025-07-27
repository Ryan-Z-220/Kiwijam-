using System.Linq;
using Microsoft.Unity.VisualStudio.Editor;
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
                var image = GetComponent<UnityEngine.UI.Image>();
                image.color = Flower.rarityColors[flower.rarity]; // reset color to rarity color

            }
            else
            {
                Inventory.EquipFlower(flower);
                var image = GetComponent<UnityEngine.UI.Image>();
                if (Inventory.equippedFlowers.Contains(flower))
                {
                    image.color = Color.powderBlue; // change color to powder blue when equipped

                }
            }

            // equipped panel update
            var equippedPanel = FindObjectOfType<EquippedPanel>();
            equippedPanel.UpdatePanel();
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
