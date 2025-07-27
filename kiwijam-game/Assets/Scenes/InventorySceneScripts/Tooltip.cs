using UnityEngine;
using TMPro;

public class Tooltip : MonoBehaviour
{
    private TMP_Text _messageText;

    public void SetTooltip(string message, Color color)
    {
        _messageText.text = message;
        _messageText.color = color;
    }
}
