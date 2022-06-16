using UnityEngine;
using UnityEngine.UIElements;
using Player;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;
    private VisualElement _root;
    private UIDocument _document;

    private Button _resumeButton;
    private Button _optionsButton;
    private Button _exitToMainMenuButton;
    private Button _exitToDekstopButton;


    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _root = GetComponent<UIDocument>().rootVisualElement;

        _resumeButton = _root.Q<Button>("ResumeButton");
        _optionsButton = _root.Q<Button>("OptionsButton");
        _exitToMainMenuButton = _root.Q<Button>("ExitToMainMenuButton");
        _exitToDekstopButton = _root.Q<Button>("ExitToDekstopButton");

        _resumeButton.clicked += ResumeButtonPressed;
        _exitToDekstopButton.clicked += ExitButtonPressed;
    }

    private void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (_playerInput.Escape)
        {
            if (_document.enabled == false)
                PauseGame();
            else
                ResumeGame();
        }
    }

    private void PauseGame()
    {
        _document.enabled = true;
        Time.timeScale = 0;
    }

    private void ResumeGame()
    {
        _document.enabled = false;
        Time.timeScale = 1;
    }

    private void ResumeButtonPressed()
    {
        Debug.Log("ButtonPressed");
        ResumeGame();
    }

    private void ExitButtonPressed()
    {
        Application.Quit();
    }
}
