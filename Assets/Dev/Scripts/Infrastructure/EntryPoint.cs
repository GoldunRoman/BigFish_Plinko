using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private IBetPanel _betPanel;
    private IScoreView _scoreView;

    [Inject]
    public void Construct(IBetPanel betPanel, IScoreView scoreView)
    {
        _betPanel = betPanel;
        _scoreView = scoreView;
    }

    private void Start()
    {
        _betPanel.Initialize();
        _scoreView.Initialize();
    }
}
