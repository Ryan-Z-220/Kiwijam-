using UnityEngine;
using TMPro;
public class ScoreUIScript : MonoBehaviour
{
    private TMP_Text _scoreText;

    public void Awake()
    {
        _scoreText = GetComponent<TMP_Text>();
    }

    public void UpdateScore(GlobalGameStateScript globalGameState)
    {
        _scoreText.text = "Score: " + globalGameState.playerScore.ToString();
    }

}
