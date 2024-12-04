using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private IBetPanel _betPanel;
    private Wallet _wallet;

    [Inject]
    public void Construct(IBetPanel betPanel, Wallet wallet)
    {
        _betPanel = betPanel;
        _wallet = wallet;
    }

    private void Start()
    {
        _betPanel.Initialize();
        _wallet.Initialize();
    }
}
