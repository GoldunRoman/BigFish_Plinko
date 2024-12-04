using System;

public interface IBetPanel
{
    public Action<int> BetChanged { get; set; }

    public void Initialize();
}