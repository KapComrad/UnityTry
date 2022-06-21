using UnityEngine;
using UnityEngine.UIElements;
using Player;

public class UIGame : MonoBehaviour
{
    private VisualElement _root;
    private UIDocument _document;

    [SerializeField] private VisualTreeAsset _visualTreeAsset;
    private VisualElement _gameUIBox;
    private void Awake()
    {
        _document = GetComponent<UIDocument>();
        _root = _document.rootVisualElement;
        _gameUIBox = _root.Q<VisualElement>("GameUIBox");

    }
    private void Start()
    {
        ChangeHealthUI();
    }

    private void ChangeHealthUI()
    {
        int healthCount = 0;
        for (int i = 0; i < _gameUIBox.childCount; i++)
        {
            if (_gameUIBox.ElementAt(i).name == "Hearth")
                healthCount++;
        }
        if (healthCount > PlayerStats.singleton.Health)
        {
            _gameUIBox.RemoveAt(0);
        }
        else if (healthCount < PlayerStats.singleton.Health)
        {
            while (healthCount < PlayerStats.singleton.Health)
            {
                var hearth = _visualTreeAsset.Instantiate();
                _gameUIBox.Add(hearth);
                hearth.name = "Hearth";
                hearth.SendToBack();
                healthCount++;
            }
        }

    }

    private void ChangeScoreUI()
    {
        var scoreNumber = _gameUIBox.Q<Label>("ScoreNumber");
        int result = PlayerStats.singleton.Score;
        scoreNumber.text = result.ToString();
    }

    private void OnEnable()
    {
        PlayerTakeDamage.PlayerTakeDamageEvent += ChangeHealthUI;
        GemPickUp.AddScoreEvent += ChangeScoreUI;
    }

    private void OnDisable()
    {
        PlayerTakeDamage.PlayerTakeDamageEvent -= ChangeHealthUI;
        GemPickUp.AddScoreEvent += ChangeScoreUI;
    }

    //private void ChangeHealthUI()
    //{
    //    VisualElement[] count = new VisualElement[_gameUIBox.childCount];
    //    for (int i = 0; i < _gameUIBox.childCount; i++)
    //    {
    //        Debug.Log(_gameUIBox.ElementAt(i).name);
    //    }

    //}

}
