﻿using LevelData;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class LaunchGame : State, IState
	{
		[Inject] ILevelData _levelData;

		public LaunchGame(IGameStateMachine gameStateMachine) : base(
			gameStateMachine)
		{ }

		public void Enter()
		{
			var devSceneRunner = _levelData.DevSceneRunner;
			if (devSceneRunner != null && devSceneRunner.TryRunScene())
				return;

			_levelData.SceneInitializer.Init();
			_gameStateMachine.Enter<GameLoop>();
		}

		public void Exit()
		{ }
	}
}