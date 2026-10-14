using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private GameObject settingsPanel;
    [SerializeField] private GameObject creditsPanel;
    [SerializeField] private GameObject menuButtons;
    [SerializeField] private Image fadeOverlay;

    [SerializeField] private float fadeDuration = 1f;
    [SerializeField] private string firstSceneName = "";

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
        creditsPanel.SetActive(false);
        menuButtons.SetActive(false);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void OpenCredits()
    {
        creditsPanel.SetActive(true);
        settingsPanel.SetActive(false);
        menuButtons.SetActive(false);
    }

    public void CloseCredits()
    {
        creditsPanel.SetActive(false);
        menuButtons.SetActive(true);
    }

    public void StartGame()
    {
        StartCoroutine(FadeAndLoadScene());
    }

    private IEnumerator FadeAndLoadScene()
    {
        fadeOverlay.gameObject.SetActive(true);

        float timer = 0f;
        Color color = fadeOverlay.color;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            float alpha = timer / fadeDuration;

            fadeOverlay.color = new Color(color.r, color.g, color.b, alpha);

            yield return null;
        }

        SceneManager.LoadScene(firstSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}