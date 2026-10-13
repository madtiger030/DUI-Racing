using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreManager_sc : MonoBehaviour
{
    public static ScoreManager_sc instance;
    public int score = 0;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        Debug.Log("Score: " + score);

    }
}
