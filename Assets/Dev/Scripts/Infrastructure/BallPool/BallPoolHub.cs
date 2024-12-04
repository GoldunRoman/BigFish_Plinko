using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BallPoolHub : MonoBehaviour
{
    [Inject] private readonly Dictionary<BallType, IMemoryPool> _pools;

    public T Spawn<T>(BallType type) where T : Ball
    {
        if (_pools.TryGetValue(type, out var pool))
        {
            T item = (pool as IMemoryPool<T>).Spawn();
            return item;
        }

        Debug.LogError($"Pool for ball type {type} not found!");
        return null;
    }
}
