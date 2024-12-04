using TMPro;
using UnityEngine;
using Zenject;

public class WalletView : MonoBehaviour
{
    [SerializeField] private TMP_Text _balanceTMP;

    private Wallet _wallet;

    [Inject]
    public void Construct(Wallet wallet)
    {
        _wallet = wallet;
    }

    private void OnEnable()
    {
        _wallet.ValueChanged += OnBalanceChanged;
    }

    private void OnDisable()
    {
        _wallet.ValueChanged -= OnBalanceChanged;
    }

    private void OnBalanceChanged(float newBalance)
    {
        _balanceTMP.text = newBalance.ToString();
    }
}