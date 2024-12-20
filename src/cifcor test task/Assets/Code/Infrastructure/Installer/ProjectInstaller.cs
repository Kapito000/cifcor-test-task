﻿using Infrastructure.AssetProvider;
using Infrastructure.GameStatus;
using Infrastructure.GameStatus.State;
using Infrastructure.SceneLoader;
using Input;
using Input.Character;
using LevelData;
using PlayerProgress;
using StaticData.GameBalance;
using StaticData.SceneNames;
using UnityEngine;
using Zenject;

namespace Infrastructure.Installer
{
	public class ProjectInstaller : MonoInstaller
	{
		[SerializeField] GameBalance _gameBalance;
		[SerializeField] SceneNamesData _sceneNamesData;
		[SerializeField] DirectLinkProvider _assetProvider;

		public override void InstallBindings()
		{
			BindLevelData();
			BindStaticData();
			PlayerProgress();
			BindSceneLoader();
			BindInputService();
			BindAssetProvider();
			BindGameStateMachine();
		}

		void PlayerProgress()
		{
			Container.Bind<IPlayerProgress>().FromMethod(CreatePlayerProgress)
				.AsSingle();
		}

		void BindInputService()
		{
			Container.Bind<Controls>().AsSingle();
			Container.Bind<IInput>().To<CommonInput>().AsSingle();
			Container.Bind<ITouch>().To<TouchHandler>().AsSingle();
		}

		void BindAssetProvider()
		{
			Container.Bind<IAssetProvider>().FromInstance(_assetProvider).AsSingle();
		}

		void BindLevelData()
		{
			Container.Bind<ILevelData>().To<StandardLevelData>().AsSingle();
		}

		void BindSceneLoader()
		{
			Container.Bind<ISceneLoader>().To<StandardLoader>().AsSingle();
		}

		void BindStaticData()
		{
			Container.Bind<ISceneNameData>().FromInstance(_sceneNamesData)
				.AsSingle();
			Container.Bind<IGameBalance>().FromInstance(_gameBalance).AsSingle();
		}

		void BindGameStateMachine()
		{
			Container.Bind<Game>().FromNew().AsSingle();

			Container.Bind<IGameStateMachine>().To<GameStateMachine>().AsSingle();
			Container.Bind<IState>().To<LoadGame>().AsSingle();
			Container.Bind<IState>().To<LoadScene>().AsSingle();
			Container.Bind<IState>().To<LaunchGame>().AsSingle();
			Container.Bind<IState>().To<GameLoop>().AsSingle();
			Container.Bind<IState>().To<GameExit>().AsSingle();
		}

		IPlayerProgress CreatePlayerProgress()
		{
			var obj = new GameObject("Player progress")
				.AddComponent<StandardPlayerProgress>();
			DontDestroyOnLoad(obj);
			return obj;
		}
	}
}