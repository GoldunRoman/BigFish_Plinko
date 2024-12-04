using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private GameStateMachine _gameStateMachine;

    [Inject]
    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    private void Start()
    {
        _gameStateMachine.ChangeState<NewGameState>();
    }
}
