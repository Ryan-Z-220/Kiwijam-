using UnityEngine;
using System.Collections;

public class PlayerStatsScript : MonoBehaviour
{
    public float movementSpeedMultiplier = 1.0f;
    public int bonusHealth = 0;
    public float bulletSpeedMultiplier = 1.0f;
    public float firingRateMultiplier = 1.0f;

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
}
