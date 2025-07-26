using UnityEngine;
using TMPro;
public class ScoreUIScript : MonoBehaviour
{
    private TMP_Text _scoreText;

    public void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
        UpdateScore();
    }

    public void UpdateScore()
    {
        _scoreText.text = "Score: " + GlobalGameStateScript.playerScore.ToString();
    }

}
