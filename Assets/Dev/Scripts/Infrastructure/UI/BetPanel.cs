using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BetPanel : MonoBehaviour, IBetPanel
{
    public Action<int> BetChanged { get; set; }

    [SerializeField] private Button _raiseBetButton;
    [SerializeField] private Button _reduceBetButton;
    [SerializeField] private TMP_Text _currentBetTMP;

    private BetConfig _config;
    private int _currentBetIndex = 0;

    #region Initialization
    [Inject]
    public void Construct(BetConfig betConfig)
    {
        _config = betConfig;
    }

    public void Initialize()
    {
        BetChanged?.Invoke(_config.AwailableBets[_currentBetIndex]);
        UpdateBetDisplay();
    }
    #endregion

    #region MonoBehaviour Methods
    private void OnEnable()
    {
        _raiseBetButton.onClick.AddListener(OnRaiseBetClick);
        _reduceBetButton.onClick.AddListener(OnReduceBetClick);
    }

    private void OnDisable()
    {
        _raiseBetButton.onClick.RemoveListener(OnRaiseBetClick);
        _reduceBetButton.onClick.RemoveListener(OnReduceBetClick);
    }
    #endregion

    #region Callbacks
    private void OnRaiseBetClick()
    {
        if (_currentBetIndex < _config.AwailableBets.Count - 1)
        {
            _currentBetIndex++;
            BetChanged?.Invoke(_config.AwailableBets[_currentBetIndex]);

            UpdateBetDisplay();
        }
    }

    private void OnReduceBetClick()
    {
        if (_currentBetIndex > 0)
        {
            _currentBetIndex--;
            BetChanged?.Invoke(_config.AwailableBets[_currentBetIndex]);
            UpdateBetDisplay();
        }
    }
    #endregion

    #region View Methods
    private void UpdateBetDisplay()
    {
        _currentBetTMP.text = _config.AwailableBets[_currentBetIndex].ToString();
        _raiseBetButton.interactable = _currentBetIndex < _config.AwailableBets.Count - 1;
        _reduceBetButton.interactable = _currentBetIndex > 0;
    }
    #endregion
}