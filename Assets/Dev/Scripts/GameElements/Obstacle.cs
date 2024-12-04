using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private readonly float _impulseForce = 0.1f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.TryGetComponent<Ball>(out var ball))
        {
            ApplyRandomImpulse(ball);
        }
    }

    private void ApplyRandomImpulse(Ball ball)
    {  
        if (ball.TryGetComponent<Rigidbody2D>(out var rb))
        {
            float direction = Random.value < 0.5f ? -1f : 1f;
            Vector2 impulse = new Vector2(_impulseForce * direction, 0f);

            rb.AddForce(impulse, ForceMode2D.Impulse);
        }
    }
}
