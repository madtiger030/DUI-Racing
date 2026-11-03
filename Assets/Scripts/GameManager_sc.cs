using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static bool GameOver = false;
    public static GameManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;

    private void Awake()
    {
        scoreText.text = "Score: 0";
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;
        Debug.Log("Score: " + score);

    }
    public static void EndGame()
    {
        if (GameOver)
            return;
        GameOver = true;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
    }
}
