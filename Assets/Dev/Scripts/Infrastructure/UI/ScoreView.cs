using TMPro;
using UnityEngine;
using Zenject;

public class ScoreView : MonoBehaviour, IScoreView
{
    [SerializeField] private TMP_Text _scoreValueTMP;

    private float _totalScore = 0;
    private SignalBus _signalBus;

    [Inject]
    public void Construct(SignalBus signalBus)
    {
        _signalBus = signalBus;
    }

    public void Initialize()
    {
        _signalBus.Subscribe<AddPointsSignal>(OnPointsAdded);

        ResetView();
    }

    public void ResetView()
    {
        _totalScore = 0f;

        UpdateScoreDisplay();
    }

    private void OnPointsAdded(AddPointsSignal signal)
    {
        _totalScore += signal.Points;

        UpdateScoreDisplay();
    }

    private void UpdateScoreDisplay()
    {
        _scoreValueTMP.text = _totalScore.ToString();
    }

    private void OnDestroy()
    {
        _signalBus.Unsubscribe<AddPointsSignal>(OnPointsAdded);
    }
}
