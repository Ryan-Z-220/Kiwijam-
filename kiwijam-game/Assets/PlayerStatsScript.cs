using UnityEngine;
using System.Collections;
using Unity.VisualScripting;

public class PlayerStatsScript : MonoBehaviour
{
    public float movementSpeedMultiplier = 1.0f;
    public float bulletSpeedMultiplier = 1.0f;
    public float firingRateMultiplier = 1.0f;
    public float scoreMultiplier = 1.0f;
    public float flowerDropRateMultiplier = 1.0f;
    public int bonusHealth = 2; // Bonus health from equipped flowers
    public bool temporarilyInvincible = false;


    public IEnumerator FlashRedAndReset(SpriteRenderer playerSprite)
    {
        Color originalColor = playerSprite.color;
        playerSprite.color = Color.red;
        temporarilyInvincible = true;
        yield return new WaitForSeconds(1f);
        playerSprite.color = originalColor;
        temporarilyInvincible = false;
    }

    public void Awake()
    {
        // calculate stats based on equipped flowers
        foreach (Flower flower in Inventory.equippedFlowers)
        {
            foreach (Modifier modifier in flower.modifiers)
            {
                switch (modifier.modifierType)
                {
                    case Modifiers.bullet_speed:
                        bulletSpeedMultiplier += modifier.value;
                        break;
                    case Modifiers.firing_rate:
                        firingRateMultiplier += modifier.value;
                        break;
                    case Modifiers.movement_speed:
                        movementSpeedMultiplier += modifier.value;
                        break;
                    case Modifiers.score:
                        scoreMultiplier += modifier.value;
                        break;
                    case Modifiers.flower_drop_rate:
                        flowerDropRateMultiplier += modifier.value;
                        break;
                }
            }
        }
    }
}
