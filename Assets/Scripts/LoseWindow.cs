using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoseWindow : MonoBehaviour
{
    [SerializeField] private GameStateManager _gameStateManager;
    [SerializeField] private Button _continueButton;

    public void Show()
    {
        gameObject.SetActive(true);
    }

    private void OnEnable()
    {
        _continueButton.onClick.AddListener(Continue);
    }

    private void Continue()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameStateManager.SetStartMenuState();
    }

    private void OnDisable()
    {
        _continueButton.onClick.RemoveListener(Continue);
    }
}
