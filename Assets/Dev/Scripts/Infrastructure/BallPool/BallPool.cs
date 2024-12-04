using Zenject;

public class BallPool<TBall> : MonoMemoryPool<TBall>
    where TBall : Ball
{
}