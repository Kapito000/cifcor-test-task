using Factory.EntityBehaviourFactory;
using Factory.Kit;
using Factory.SystemFactory;
using Feature;
using Feature.HUD.Factory;
using Feature.Player.Factory;
using Feature.Tap.Factory;
using Gameplay.Collisions;
using Infrastructure.Boot;
using Infrastructure.ECS;
using Infrastructure.GameStatus;
using Infrastructure.GameStatus.State;
using InstantiateService;
using Leopotam.EcsLite;
using LevelData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installer
{
	public class LevelInstaller : MonoInstaller, IInitializable
	{
		[SerializeField] EcsRunner _ecsRunner;

		[Inject] ILevelData _levelData;
		[Inject] IGameStateMachine _gameStateMachine;

		public override void InstallBindings()
		{
			BindInitializable();
			BindWorld();
			BindFactories();
			BindFactoryKit();
			BindUiFactories();
			BindInstantiator();
			BindSystemFactory();
			BindDevSceneRunner();
			BindCollisionRegistry();
			BindFeatureController();
		}

		public void Initialize()
		{
			InitLevelData();
			_gameStateMachine.Enter<LaunchGame>();
		}

		void InitLevelData()
		{
			_levelData.EcsRunner = _ecsRunner;
			_levelData.DevSceneRunner = Container.Resolve<IDevSceneRunner>();
		}

		void BindCollisionRegistry()
		{
			Container.Bind<ICollisionRegistry>().To<CollisionRegistry>().AsSingle();
		}

		void BindUiFactories()
		{
			Container.Bind<IHudFactory>().To<HudFactory>().AsSingle();
			Container.Bind<ITapFactory>().To<TapFactory>().AsSingle();
		}

		void BindDevSceneRunner()
		{
			Container.Bind<IDevSceneRunner>().FromComponentInHierarchy().AsSingle();
		}

		void BindInstantiator()
		{
			Container.Bind<IInstantiateService>().To<StandardInstantiateService>()
				.AsSingle();
		}

		void BindFactoryKit()
		{
			Container.Bind<IFactoryKit>().To<FactoryKit>().AsSingle();
		}

		void BindFactories()
		{
			Container.Bind<IPlayerFactory>().To<PlayerFactory>().AsSingle();
			Container.Bind<IEntityBehaviourFactory>().To<EntityBehaviourFactory>()
				.AsSingle();
		}

		void BindFeatureController()
		{
			Container.Bind<FeatureController>().AsSingle();
		}

		void BindSystemFactory()
		{
			Container.Bind<ISystemFactory>().To<StandardSystemFactory>().AsSingle();
		}

		void BindWorld()
		{
			Container.Bind<EcsWorld>().FromInstance(new EcsWorld()).AsSingle();
		}

		void BindInitializable()
		{
			Container.BindInterfacesTo<LevelInstaller>().FromInstance(this)
				.AsSingle();
		}
	}
}