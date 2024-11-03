﻿using Infrastructure.GameStatus;
using Infrastructure.GameStatus.State;
using StaticData.SceneNames;
using Zenject;

namespace Infrastructure
{
	public sealed class Game
	{
		[Inject] ISceneNameData _sceneName;
		[Inject] IGameStateMachine _gameStateMachine;

		public bool Started { get; private set; }
		public string CustomScene { get; set; }

		public void Start()
		{
			Started = true;

			var firstScene = LaunchFromCustomScene()
				? CustomScene
				: _sceneName.FirstGameSceneName;

			_gameStateMachine.GetState<LoadGame>().FirstScene = firstScene;
			_gameStateMachine.Enter<LoadGame>();
		}

		bool LaunchFromCustomScene()
		{
			return string.IsNullOrEmpty(CustomScene) == false;
		}
	}
}