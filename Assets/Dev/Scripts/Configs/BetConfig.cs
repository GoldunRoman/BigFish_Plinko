using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BetConfig", menuName = "Custom/Configs/BetConfig")]
public class BetConfig : ScriptableObject
{
    [SerializeField] private List<int> _awailableBets;
    public IReadOnlyList<int> AwailableBets { get { return _awailableBets; } }
}
