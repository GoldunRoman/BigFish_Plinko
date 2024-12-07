using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class GameSceneInstaller : MonoInstaller
{
    [Header("Instances")]
    [SerializeField] private BallPrefabAtlas _ballPrefabAtlas;
    [SerializeField] private BetConfig _betConfig;
    [SerializeField] private BetPanel _betPanel;
    [SerializeField] private UIController _uiController;
    [SerializeField] private Transform _ballsPoolContainer;

    public override void InstallBindings()
    {
        #region General Bindings
        Container.Bind<BallPrefabAtlas>().FromInstance(_ballPrefabAtlas).AsSingle();
        Container.Bind<BetConfig>().FromInstance(_betConfig).AsSingle();
        Container.Bind<IBetPanel>().To<BetPanel>().FromInstance(_betPanel).AsSingle();
        Container.Bind<IUIController>().To<UIController>().FromInstance(_uiController).AsSingle();
        Container.Bind<Transform>().FromInstance(_ballsPoolContainer).AsSingle();
        Container.Bind<GameStateMachine>().AsSingle().WithArguments(Container);
        Container.Bind<Wallet>().AsSingle();
        #endregion

        #region Ball Pool Bindings
        Container.BindMemoryPool<GreenBall, BallPool<GreenBall>>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_ballPrefabAtlas.GetBallPrefab(BallType.Green))
            .UnderTransform(_ballsPoolContainer);

        Container.BindMemoryPool<YellowBall, BallPool<YellowBall>>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_ballPrefabAtlas.GetBallPrefab(BallType.Yellow))
            .UnderTransform(_ballsPoolContainer);

        Container.BindMemoryPool<RedBall, BallPool<RedBall>>()
            .WithInitialSize(20)
            .FromComponentInNewPrefab(_ballPrefabAtlas.GetBallPrefab(BallType.Red))
            .UnderTransform(_ballsPoolContainer);


        Container.Bind<Dictionary<BallType, IMemoryPool>>()
            .FromMethod(CreateBallPools)
            .AsSingle();

        Container.Bind<BallPoolHub>().AsSingle();
        #endregion
    }

    private Dictionary<BallType, IMemoryPool> CreateBallPools(InjectContext context)
    {
        Dictionary<BallType, IMemoryPool> pools = new Dictionary<BallType, IMemoryPool>();

        MemoryPool<GreenBall> greenBallPool = Container.Resolve<BallPool<GreenBall>>();
        MemoryPool<YellowBall> yellowBallPool = Container.Resolve<BallPool<YellowBall>>();
        MemoryPool<RedBall> redBallPool = Container.Resolve<BallPool<RedBall>>();

        return new Dictionary<BallType, IMemoryPool>
        {
            { BallType.Green, greenBallPool },
            { BallType.Yellow, yellowBallPool },
            { BallType.Red, redBallPool }
        };
    }
}
