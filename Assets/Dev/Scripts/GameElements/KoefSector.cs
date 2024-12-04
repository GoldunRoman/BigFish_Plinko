using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider2D))]
public class KoefSector : MonoBehaviour
{
    [SerializeField] private BallType _targetBall;
    [SerializeField][Range(0, 10)] private float _koeficient;
    [SerializeField] private TMP_Text _text;

    private IBetPanel _betPanel;
    private Wallet _wallet;

    private int _currentBet;

    [Inject]
    public void Construct(IBetPanel betPanel, Wallet wallet)
    {
        _betPanel = betPanel;
        _wallet = wallet;
    }

    private void OnValidate()
    {
        _text.text = $"x {_koeficient}";
    }

    private void OnEnable()
    {
        _betPanel.BetChanged += OnBetChanged;
    }

    private void OnDisable()
    {
        _betPanel.BetChanged -= OnBetChanged;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.TryGetComponent<Ball>(out var ball))
        {
            if (_targetBall != ball.BallType)
                return;

            _wallet.AddFunds(_currentBet * _koeficient);

            ball.Despawn();
        }
    }

    private void OnBetChanged(int currentBet) => _currentBet = currentBet;
}