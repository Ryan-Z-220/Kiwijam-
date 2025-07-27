using UnityEngine;
using TMPro;
public class DeathMessageScript : MonoBehaviour
{
    private TMP_Text _messageText;

    public void Awake()
    {
        _messageText = GetComponent<TMP_Text>();
        _messageText.enabled = false; // Initially hide the message
    }

    public void ShowDeathMessage()
    {
        //find inventory button by its tag
        GameObject inventoryButton = GameObject.FindGameObjectWithTag("InventoryTag");
        if (inventoryButton == null)
        {
            inventoryButton.SetActive(true);
        }
        _messageText.enabled = true;
        _messageText.text = "You've been caught by a spider! Game Over.\n Final Score: " + GlobalGameStateScript.playerScore.ToString() + "\n Press R to restart.";
        // hide the ScoreDisplay
        GameObject scoreDisplay = GameObject.Find("ScoreDisplay");
        if (scoreDisplay != null)
        {
            scoreDisplay.SetActive(false);
        }

    }

}
