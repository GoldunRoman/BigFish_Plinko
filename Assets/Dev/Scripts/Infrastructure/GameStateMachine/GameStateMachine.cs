using Zenject;

public class GameStateMachine
{
    private IGameState _currentState;
    private readonly DiContainer _container;

    public GameStateMachine(DiContainer container)
    {
        _container = container;
    }

    public void ChangeState<T>() where T : IGameState
    {
        _currentState = _container.Instantiate<T>();
        _currentState.Enter();
    }
}