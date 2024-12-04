using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class BallSpawner : MonoBehaviour
{
    [SerializeField] private Button _greenSpawnButton;
    [SerializeField] private Button _yellowSpawnButton;
    [SerializeField] private Button _redSpawnButton;

    [SerializeField] private Transform _spawnTransform;

    private BallPoolHub _poolHub;

    [Inject]
    public void Construct(BallPoolHub poolHub)
    {
        _poolHub = poolHub;
    }

    private void OnEnable()
    {
        _greenSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Green));
        _yellowSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Yellow));
        _redSpawnButton.onClick.AddListener(() => OnSpawnButtonClick(BallType.Red));
    }

    private void OnDisable()
    {
        _greenSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Green));
        _yellowSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Yellow));
        _redSpawnButton.onClick.RemoveListener(() => OnSpawnButtonClick(BallType.Red));
    }

    private void OnSpawnButtonClick(BallType ballType)
    {
        if (_poolHub == null)
        {
            Debug.LogError("<color=magenta>[BallSpawner]</color> _poolHub is <b>null</b>!");
            return;
        }

        Ball ball = _poolHub.Spawn(ballType);
        ball.transform.position = _spawnTransform.position;
    }
}
