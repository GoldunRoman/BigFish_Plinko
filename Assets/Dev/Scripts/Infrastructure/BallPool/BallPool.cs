using System;
using UnityEngine;
using Zenject;

public class BallPool<TBall> : MonoMemoryPool<TBall>
    where TBall : Ball
{
    [Inject] private readonly BallPrefabAtlas _ballPrefabAtlas;

    protected TBall CreateBall(BallType type)
    {
        TBall prefab = _ballPrefabAtlas.GetBallPrefab(type) as TBall;

        if (prefab == null)
        {
            throw new Exception("Prefab not found for ball type: " + type);
        }

        return GameObject.Instantiate(prefab);
    }

    protected override void Reinitialize(TBall item)
    {
        item.gameObject.SetActive(true);
    }

    protected override void OnDespawned(TBall item)
    {
        item.gameObject.SetActive(false);
    }
}