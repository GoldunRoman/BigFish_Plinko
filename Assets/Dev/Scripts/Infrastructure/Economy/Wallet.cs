using System;
using Zenject;

public class Wallet
{
    public Action<float> ValueChanged;

    private GameStateMachine _gameStateMachine;

    private const float DEFAULT_BALANCE = 500f;
    private float _balance;

    [Inject]
    public void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }

    public void Initialize()
    {
        ResetBalance();
    }

    public void AddFunds(float amount)
    {
        _balance += amount;
        ValueChanged?.Invoke(_balance);
        CheckForGameOver();
    }

    public bool TrySpend(float amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            ValueChanged?.Invoke(_balance);
            CheckForGameOver();
            return true;
        }

        _gameStateMachine.ChangeState<GameOverState>();
        return false;
    }

    private void ResetBalance()
    {
        _balance = DEFAULT_BALANCE;
        ValueChanged?.Invoke(_balance);
    }

    private void CheckForGameOver()
    {
        if (_balance <= 0)
        {
            _gameStateMachine.ChangeState<GameOverState>();
        }
    }
}
