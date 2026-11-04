using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject gameOverPanel;
    public TextMeshProUGUI finalScoreText;
    public static bool GameOver = false;
    public static GameManager instance;
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public float gameSpeed = 1f;
    public float speedIncrease = 0.1f;
    public float maxGameSpeed = 3f;
    public float turnSpeedMultiplier = 1f;
    public float turnSpeedIncrease = 0.05f;
    public float maxTurnSpeedMultiplier = 2.5f;

    private void Awake()
    {
        scoreText.text = "Score: 0";
        instance = this;
        gameOverPanel.SetActive(false);
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoreText.text = "Score: " + score;

        // Increase difficulty based on collected objects
        gameSpeed = Mathf.Min(gameSpeed + speedIncrease * amount, maxGameSpeed);

        turnSpeedMultiplier = Mathf.Min(
            turnSpeedMultiplier + turnSpeedIncrease * amount,
            maxTurnSpeedMultiplier
        );

    }
    public static void EndGame()
    {
        if (GameOver)
            return;
        GameOver = true;

        instance.gameOverPanel.SetActive(true);
        instance.finalScoreText.text = "SCORE: " + instance.score;
        Time.timeScale = 0f;
        Debug.Log("GAME OVER");
    }
    public void PlayAgain()
    {
        Time.timeScale = 1f;
        GameOver = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("QUITTING GAME");
    }
}
