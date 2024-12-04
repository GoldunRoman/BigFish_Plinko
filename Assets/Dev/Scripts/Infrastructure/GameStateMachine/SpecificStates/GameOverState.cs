using UnityEngine;
using Zenject;

public class GameOverState : IGameState
{
    private const float FREEZE_TIMESCALE = 0.0000000001f;

    private IUIController _uiController;

    [Inject]
    public void Construct(IUIController uiController)
    {
        _uiController = uiController;
    }

    public void Enter()
    {
        _uiController.ShowWindow(WindowType.GameOver);

        Time.timeScale = FREEZE_TIMESCALE;
    }
}

