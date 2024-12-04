using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallPoolHub
{
    private readonly Dictionary<BallType, Func<Ball>> _spawnFunctions;

    [Inject]
    public BallPoolHub(
        BallPool<GreenBall> greenPool,
        BallPool<YellowBall> yellowPool,
        BallPool<RedBall> redPool)
    {
        _spawnFunctions = new Dictionary<BallType, Func<Ball>>
        {
            { BallType.Green, () => greenPool.Spawn() },
            { BallType.Yellow, () => yellowPool.Spawn() },
            { BallType.Red, () => redPool.Spawn() }
        };

        Debug.Log("<color=magenta>[BallPoolHub]</color> Pools successfully injected.");
    }

    public Ball Spawn(BallType type)
    {
        if (_spawnFunctions.TryGetValue(type, out var spawnFunction))
        {
            Ball ball = spawnFunction.Invoke();
            Debug.Log($"<color=magenta>[BallPoolHub]</color> Spawned {type} ball.");
            return ball;
        }

        Debug.LogError($"<color=magenta>[BallPoolHub]</color> Pool for ball type {type} not found!");
        return null;
    }
}
