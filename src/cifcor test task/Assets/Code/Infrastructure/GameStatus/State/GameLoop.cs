using Input.Character;
using Zenject;

namespace Infrastructure.GameStatus.State
{
	public sealed class GameLoop : State, IState
	{
		[Inject] ITouch _touch;

		public GameLoop(IGameStateMachine gameStateMachine) :
			base(gameStateMachine)
		{ }

		public void Enter()
		{
			_touch.Enable();
		}

		public void Exit()
		{
			_touch.Disable();
		}
	}
}