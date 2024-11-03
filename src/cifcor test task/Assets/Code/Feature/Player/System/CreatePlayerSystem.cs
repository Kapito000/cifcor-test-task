using Feature.Player.Factory;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.Player.System
{
	public sealed class CreatePlayerSystem : IEcsInitSystem
	{
		[Inject] IPlayerFactory _playerFactory;
		
		public void Init(IEcsSystems systems)
		{
			_playerFactory.CreatePlayer();
		}
	}
}