using UnityEngine;
using Zenject;

public class EntryPoint : MonoBehaviour
{
    private IBetPanel _betPanel;

    private void Start()
    {
        _betPanel.Initialize();
    }

    [Inject]
    public void Construct(IBetPanel betPanel)
    {
        _betPanel = betPanel;
    }
}
