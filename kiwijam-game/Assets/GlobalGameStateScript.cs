using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalGameStateScript : MonoBehaviour
{
    public UnityEvent OnScoreChanged;
    public UnityEvent OnGameOver;

    public int playerScore = 0;
    public bool isGameOver = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void Awake()
    {
        if (OnScoreChanged == null)
            OnScoreChanged = new UnityEvent();

        if (OnGameOver == null)
            OnGameOver = new UnityEvent();
    }

    public void ChangeScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Score changed: " + playerScore);
        OnScoreChanged.Invoke();
    }

    public void GameOver()
    {
        isGameOver = true;
        Debug.Log("Game Over! Final Score: " + playerScore);
        OnGameOver.Invoke();
    }
}
