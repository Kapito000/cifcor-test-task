using Factory.Kit;
using Feature.TapFactory;
using Feature.TapProcessor;
using Infrastructure.Boot;
using Infrastructure.GameStatus;
using Infrastructure.GameStatus.State;
using Infrastructure.SceneInitializer;
using InstantiateService;
using LevelData;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installer
{
	public class LevelInstaller : MonoInstaller, IInitializable
	{
		[SerializeField] StandardSceneInitializer sceneInitializer; 
		
		[Inject] ILevelData _levelData;
		[Inject] IGameStateMachine _gameStateMachine;

		public override void InstallBindings()
		{
			BindInitializable();
			TapFactory();
			BindFactoryKit();
			BindInstantiator();
			BindTapProcessor();
			BindDevSceneRunner();
		}

		public void Initialize()
		{
			InitLevelData();
			_gameStateMachine.Enter<LaunchGame>();
		}

		void InitLevelData()
		{
			_levelData.SceneInitializer = sceneInitializer;
			_levelData.DevSceneRunner = Container.Resolve<IDevSceneRunner>();
		}

		void TapFactory()
		{
			Container.Bind<ITapFactory>().To<TapFactory>().AsSingle();
		}

		void BindTapProcessor()
		{
			Container.Bind<ITapProcessor>().To<StandardTapProcessor>().AsSingle();
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

		void BindInitializable()
		{
			Container.BindInterfacesTo<LevelInstaller>().FromInstance(this)
				.AsSingle();
		}
	}
}