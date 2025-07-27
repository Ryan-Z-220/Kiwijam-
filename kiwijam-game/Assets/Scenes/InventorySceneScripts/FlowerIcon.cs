using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class FlowerIcon : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    public Flower flower;

    public UnityEngine.Sprite white_flower;
    public UnityEngine.Sprite blue_flower;
    public UnityEngine.Sprite red_flower;

    public FlowerIcon(Flower flower)
    {
        this.flower = flower;
    }

    void Start()
    {
        // change the icon's color based on the flower's rarity
        var image = GetComponent<UnityEngine.UI.Image>();
        if (Flower.rarityColors[flower.rarity] == Color.red)
        {
            image.sprite = red_flower;
        }
        else if (Flower.rarityColors[flower.rarity] == Color.blue)
        {
            image.sprite = blue_flower;
        }
        else
        {
            image.sprite = white_flower;
        }

        if (flower.isEquipped)
        {
            image.color = Color.yellow; // change color to yellow when equipped
        }
        else
        {
            image.color = Color.white; // set color to rarity color
        }
    }

    public virtual void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.clickCount == 2)
        {
            if (flower.isEquipped)
            {
                Inventory.UnequipFlower(flower);
                var image = GetComponent<UnityEngine.UI.Image>();

                image.color = Color.white; // reset color

            }
            else
            {
                Inventory.EquipFlower(flower);
                var image = GetComponent<UnityEngine.UI.Image>();
                if (Inventory.equippedFlowers.Contains(flower))
                {
                    image.color = Color.yellow; // change color to yellow when equipped

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
