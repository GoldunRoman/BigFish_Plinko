using TMPro;
using UnityEngine;
using Zenject;

[RequireComponent(typeof(BoxCollider2D))]
public class KoefSector : MonoBehaviour
{
    [SerializeField][Range(0, 10)] private float _koeficient;
    [SerializeField] private TMP_Text _text;

    private SignalBus _signalBus;
    private IBetPanel _betPanel;

    private int _currentBet;

    [Inject]
    public void Construct(SignalBus signalBus, IBetPanel betPanel)
    {
        _signalBus = signalBus;
        _betPanel = betPanel;
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
            _signalBus.Fire(new AddPointsSignal { Points = _currentBet * _koeficient });
            ball.Despawn();
        }
    }

    private void OnBetChanged(int currentBet) => _currentBet = currentBet;
}