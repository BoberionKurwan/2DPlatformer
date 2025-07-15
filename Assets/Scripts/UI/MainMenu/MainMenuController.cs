using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private GameObject menuBackground;
    [SerializeField] private GameObject authorsPanel;
    [SerializeField] private string gameSceneName = "Game";

    private bool isAuthorsPanelActive = false;

    public void PlayGame()
    {
        Invoke(nameof(LoadGameScene), 1f);
    }

    public void ShowAbout()
    {
        menuBackground.SetActive(false);
        authorsPanel.SetActive(true);
        isAuthorsPanelActive = true;
    }

    public void ExitGame()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }

    public void ReturnToMainMenu()
    {
        authorsPanel.SetActive(false);
        menuBackground.SetActive(true);
        isAuthorsPanelActive = false;
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}