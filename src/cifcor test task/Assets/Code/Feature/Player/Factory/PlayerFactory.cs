using Feature.Player.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.Player.Factory
{
	public sealed class PlayerFactory : IPlayerFactory
	{
		[Inject] EcsWorld _world;
		[Inject] EntityWrapper _player;

		public int CreatePlayer()
		{
			var e = _world.NewEntity();
			_player.SetEntity(e);
			_player.Add<PlayerComponent>();
			return e;
		}
	}
}