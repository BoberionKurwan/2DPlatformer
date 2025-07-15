using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [SerializeField] private Button _play;
    [SerializeField] private Button _showAuthors;
    [SerializeField] private Button _exit;
    [SerializeField] private Button _authorExit;

    [SerializeField] private GameObject menuBackground;
    [SerializeField] private GameObject authorsPanel;
    [SerializeField] private string gameSceneName = "Game";

    private void OnEnable()
    {
        _play.onClick.AddListener(LoadGameScene);
        _showAuthors.onClick.AddListener(ShowAboutAuthors);
        _exit.onClick.AddListener(ExitGame);
        _authorExit.onClick.AddListener(ReturnToMainMenu);
    }

    public void ShowAboutAuthors()
    {
        menuBackground.SetActive(false);
        authorsPanel.SetActive(true);
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
    }

    private void LoadGameScene()
    {
        SceneManager.LoadScene(gameSceneName);
    }
}