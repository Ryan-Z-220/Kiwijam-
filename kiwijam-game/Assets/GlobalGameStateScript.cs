using UnityEngine;
using UnityEngine.Events;

public class GlobalGameStateScript : MonoBehaviour
{
    public UnityEvent OnScoreChanged;

    public int playerScore = 0;

    private void Awake()
    {
        if (OnScoreChanged == null)
            OnScoreChanged = new UnityEvent();
    }

    public void ChangeScore(int amount)
    {
        playerScore += amount;
        Debug.Log("Score changed: " + playerScore);
        OnScoreChanged.Invoke();
    }
}
