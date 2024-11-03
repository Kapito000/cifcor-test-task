using Factory.Kit;
using Feature.Input.Component;
using Feature.Tap.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Zenject;

namespace Feature.Tap.Factory
{
	public sealed class TapFactory : ITapFactory
	{
		[Inject] EcsWorld _world;
		[Inject] IFactoryKit _kit;
		[Inject] EntityWrapper _tapTarget;
		[Inject] EntityWrapper _tapHandler;

		public int CreateTapHandler()
		{
			var e = _world.NewEntity();
			_tapHandler.SetEntity(e);
			_tapHandler
				.Add<InputListener>()
				.Add<TapListener>()
				;
			return e;
		}

		public int CreateTapTarget()
		{
			var prefab = _kit.AssetProvider.TapTarget();
			var instance = _kit.InstantiateService.Instantiate(prefab);
			var e = _kit.EntityBehaviourFactory.InitEntityBehaviour(instance);
			_tapTarget.SetEntity(e);
			_tapTarget
				.Add<TapTarget>()
				;
			return e;
		}
	}
}