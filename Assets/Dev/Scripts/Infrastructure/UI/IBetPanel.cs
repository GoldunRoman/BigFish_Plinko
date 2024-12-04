using System;

public interface IBetPanel
{
    public Action<int> BetChanged { get; }

    public void Initialize();
}