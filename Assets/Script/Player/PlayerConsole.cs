using UnityEngine;
using UnityEngine.UIElements;
using System.Collections.Generic;
using Player;

public class PlayerConsole : MonoBehaviour
{
    [SerializeField] private PlayerInput _playerInput;

    private VisualElement _root;
    private UIDocument _document;
    private VisualElement _consoleBox;
    private TextField _consoleOutput;
    private ProgressBar _consoleProgress;

    private List<string> _hackerWords = new List<string>()
    {
        $"Fisrt interaction \n",
        $"Second interaction \n",
        $"Third interaction \n",
        $"Fourth interaction \n",
        $"Fifth interaction \n",
        $"Sixth interaction \n",
        $"Seventh interaction \n",
        $"Eighth interaction \n",
        $"Ninth interaction \n",
        $"Tenth interaction \n",
        $"Eleventh interaction \n",
        $"Twelfth interaction \n",
        $"Thirteenth interaction \n",
        $"Fourteenth interaction \n",
        $"Fifteenth interaction \n",
        $"Sixteenth interaction \n",
        $"Seventeenth interaction \n",
        $"Eighteenth interaction \n",
        $"Nineteenth interaction \n",
        $"Twentieth interaction \n",
    };
    private int _indexList = 0;

    private bool _consoleMenuOpened;

    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;

        _consoleBox = _root.Q<VisualElement>("ConsoleBox");
        _consoleOutput = _consoleBox.Q<TextField>("ConsoleOutput");
        _consoleProgress = _consoleBox.Q<ProgressBar>("ConsoleProgress");


        _root.style.display = DisplayStyle.None;
    }

    private void Update()
    {
        ConsoleMenu();
        CheckInput();
    }
    private void ConsoleMenu()
    {
        if (_playerInput.Tab)
        {
            if (_consoleMenuOpened == false)
                ConsoleOpen();
            else
                ConsoleClose();
        }
    }

    private void ConsoleOpen()
    {
        _root.style.display = DisplayStyle.Flex;
        _consoleMenuOpened = true;
    }

    private void ConsoleClose()
    {
        _root.style.display = DisplayStyle.None;
        _consoleMenuOpened = false;
    }

    private void CheckInput()
    {
        if (Input.anyKeyDown && _consoleMenuOpened && _indexList < 20)
        {
            _consoleOutput.value += _hackerWords[_indexList];
            _consoleProgress.value++;
            _indexList++;
        }
    }

}
