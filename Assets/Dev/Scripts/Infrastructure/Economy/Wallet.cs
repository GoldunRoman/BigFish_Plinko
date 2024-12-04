using System;

public class Wallet : IGameOverRunner
{
    public Action GameOver { get; set; }
    public Action<float> ValueChanged;

    private const float DEFAULT_BALANCE = 2000f;
    private float _balance;

    public float Balance => _balance;


    public void Initialize()
    {
        ResetBalance();
    }

    public void AddFunds(float amount)
    {
        _balance += amount;
        ValueChanged?.Invoke(_balance);
    }

    public bool TrySpend(float amount)
    {
        if (_balance >= amount)
        {
            _balance -= amount;
            ValueChanged?.Invoke(_balance);
            return true;
        }

        GameOver?.Invoke();
        return false;
    }

    private void ResetBalance()
    {
        _balance = DEFAULT_BALANCE;
        ValueChanged?.Invoke(_balance);
    }
}
