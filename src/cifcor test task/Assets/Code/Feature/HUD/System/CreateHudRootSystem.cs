using Feature.HUD.Factory;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.HUD.System
{
	public sealed class CreateHudRootSystem : EcsSystem, IEcsInitSystem
	{
		[Inject] IHudFactory _hudFactory;
		[Inject] EntityWrapper _rootEntity;

		public void Init(IEcsSystems systems)
		{
			_hudFactory.CreateHudRoot();
			_hudFactory.CreateEventSystem();
		}
	}
}