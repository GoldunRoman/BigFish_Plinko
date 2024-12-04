using UnityEngine;
using Zenject;

public class NewGameState : IGameState
{
    private Wallet _wallet;
    private IBetPanel _betPanel;
    private IUIController _uiController;
    private Transform _poolContainer;

    [Inject]
    public void Construct(IBetPanel betPanel, Wallet wallet, IUIController uiController, Transform poolContainer)
    {
        _betPanel = betPanel;
        _wallet = wallet;
        _uiController = uiController;
        _poolContainer = poolContainer;
    }

    public void Enter()
    {
        foreach (Transform child in _poolContainer)
        {
            child.gameObject.SetActive(false);
        }

        _betPanel.Initialize();
        _wallet.Initialize();
        _uiController.Initialize();

        Time.timeScale = 1f;
    }
}
