using UnityEngine;
using UnityEngine.UIElements;
using Player;

public class UIController : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private VisualElement _root;
    private VisualElement _buttonBox;
    private UIDocument _document;

    private Button _resumeButton;
    private Button _optionsButton;
    private Button _exitToMainMenuButton;
    private Button _exitToDekstopButton;

    private bool _pauseMenuOpened;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;
        _buttonBox = _root.Q<VisualElement>("ButtonBox");

        _resumeButton = _buttonBox.Q<Button>("ResumeButton");
        _optionsButton = _buttonBox.Q<Button>("OptionsButton");
        _exitToMainMenuButton = _buttonBox.Q<Button>("ExitToMainMenuButton");
        _exitToDekstopButton = _buttonBox.Q<Button>("ExitToDekstopButton");

        _resumeButton.clicked += ResumeButtonPressed;
        _exitToDekstopButton.clicked += ExitButtonPressed;
        _root.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        PauseMenu();
    }

    private void PauseMenu()
    {
        if (_playerInput.Escape)
        {
            if (_pauseMenuOpened == false)
                PauseGame();
            else
                ResumeGame();
        }
    }

    private void PauseGame()
    {
        _root.style.display = DisplayStyle.Flex;
        Time.timeScale = 0;
        _pauseMenuOpened = true;
    }

    private void ResumeGame()
    {
        _root.style.display = DisplayStyle.None;
        Time.timeScale = 1;
        _pauseMenuOpened = false;
    }

    private void ResumeButtonPressed()
    {
        ResumeGame();
    }

    private void ExitButtonPressed()
    {
        Application.Quit();
    }
}
