using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool GameOver = false;
    public static GameManager instance;
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
    public static void EndGame()
    {
        GameOver = true;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
    }
}
