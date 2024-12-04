using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Button _greenSpawnButton;
    [SerializeField] private Button _yellowSpawnButton;
    [SerializeField] private Button _redSpawnButton;

    [SerializeField] private Transform _spawnTransform;

    private BallPoolHub _poolHub;
    private Wallet _wallet;
    private IBetPanel _betPanel;

    private int _currentBet;

    [Inject]
    public void Construct(BallPoolHub poolHub, Wallet wallet, IBetPanel betPanel)
    {
        _poolHub = poolHub;
        _wallet = wallet;
        _betPanel = betPanel;
    }

    private void OnEnable()
    {
        _greenSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Green));
        _yellowSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Yellow));
        _redSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Red));

        _betPanel.BetChanged += (int currentBet) => _currentBet = currentBet;

    }

    private void OnDisable()
    {
        _greenSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Green));
        _yellowSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Yellow));
        _redSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Red));

        _betPanel.BetChanged -= (int currentBet) => _currentBet = currentBet;
    }

    private void OnSpawnButtonClick(BallType ballType)
    {
        if (_wallet.TrySpend(_currentBet))
        {
            Ball ball = _poolHub.Spawn(ballType);
            ball.transform.position = _spawnTransform.position;
        }
    }
}
