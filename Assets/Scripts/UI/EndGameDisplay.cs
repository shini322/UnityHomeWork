using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(CanvasGroup))]
public class EndGameDisplay : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Button _repeatGameButton;
    [SerializeField] private Button _exitButton;
    
    private CanvasGroup _canvasGroup;

    private void Start()
    {
        _canvasGroup = GetComponent<CanvasGroup>();
        _player.WasDied += EndGame;
        _repeatGameButton.onClick.AddListener(RepeatGame);
        _exitButton.onClick.AddListener(ExitGame);
    }

    private void EndGame()
    {
        Time.timeScale = 0;
        _canvasGroup.alpha = 1;
    }

    private void RepeatGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    private void ExitGame()
    {
        Application.Quit();
    }
}
