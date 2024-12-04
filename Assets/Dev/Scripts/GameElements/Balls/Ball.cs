using UnityEngine;

public class Ball : MonoBehaviour
{
    [field: SerializeField] public BallType BallType { get; protected set; } 

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}
