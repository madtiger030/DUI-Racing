using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;

    
    void Update()
    {

        if (scoreText == null)
        {
            Debug.LogError("scoreText est NULL sur " + gameObject.name);
            return;
        }

        scoreText.text = "Score: " + GameManager.instance.score;
    }
}
