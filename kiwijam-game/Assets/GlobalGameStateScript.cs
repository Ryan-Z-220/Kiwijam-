using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class GlobalGameStateScript : MonoBehaviour
{

    public UnityEvent OnScoreChanged;
    public UnityEvent OnGameOver;

    public static int playerScore = 0;
    public bool isGameOver = false;

    public static float scoreMultiplier = 1.0f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            playerScore = 0;
            OnScoreChanged.Invoke();
            // SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            SceneManager.LoadScene("InventoryScene");
            Time.timeScale = 1;

        }
    }

    private void Awake()
    {
        OnScoreChanged ??= new UnityEvent();

        OnGameOver ??= new UnityEvent();
    }

    public void ChangeScore(int amount)
    {
        playerScore += Mathf.RoundToInt(amount * scoreMultiplier);
        OnScoreChanged.Invoke();
    }

    public void GameOver()
    {
        isGameOver = true;
        OnGameOver.Invoke();
    }
}
