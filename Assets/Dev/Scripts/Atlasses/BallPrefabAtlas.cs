using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[CreateAssetMenu(fileName = "BallPrefabAtlas", menuName = "Custom/Atlasses/BallPrefabAtlas")]
public class BallPrefabAtlas : ScriptableObject
{
    [SerializeField] private List<BallData> _ballsData;

    private void OnValidate()
    {
        if(_ballsData != null)
        {
            foreach (BallData ballData in _ballsData)
            {
                if (ballData.Prefab != null)
                {
                    ballData.BallType = ballData.Prefab.BallType;
                }
            }
        }
    }

    public Ball GetBallPrefab(BallType ballType)
    {
        BallData ballData = _ballsData.FirstOrDefault(b => b.BallType == ballType);

        if (ballData == null)
        {
            Debug.LogError($"No prefab found for ball type: {ballType}");
            return null;
        }
        return ballData.Prefab;
    }

    [System.Serializable]
    public class BallData
    {
        [field: SerializeField] public Ball Prefab { get; private set; }
        [field: SerializeField] public BallType BallType { get; set; }
    }
}
