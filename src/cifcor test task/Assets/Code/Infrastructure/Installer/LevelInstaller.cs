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
		[SerializeField] Camera _camera; 
		[SerializeField] StandardSceneInitializer _sceneInitializer; 
		
		[Inject] ILevelData _levelData;
		[Inject] IGameStateMachine _gameStateMachine;

		public override void InstallBindings()
		{
			BindInitializable();
			BindCamera();
			BindTapFactory();
			BindFactoryKit();
			BindInstantiator();
			BindTapProcessor();
			BindDevSceneRunner();
			BindAccrualModifier();
		}

		public void Initialize()
		{
			InitLevelData();
			_gameStateMachine.Enter<LaunchGame>();
		}

		void InitLevelData()
		{
			_levelData.SceneInitializer = _sceneInitializer;
			_levelData.DevSceneRunner = Container.Resolve<IDevSceneRunner>();
		}

		void BindAccrualModifier()
		{
			Container.Bind<IAccrualModifier>().To<StandardAccrualModifier>().AsSingle();
		}

		void BindCamera()
		{
			Container.BindInstance(_camera).AsSingle();
		}

		void BindTapFactory()
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