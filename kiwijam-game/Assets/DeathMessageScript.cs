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
        _messageText.enabled = true;
        _messageText.text = "You've been caught by a spider! Game Over.\n Final Score: " + GlobalGameStateScript.playerScore.ToString();
    }

}
