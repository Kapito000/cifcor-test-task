using Extensions;
using Factory.Kit;
using Feature.HUD.Component;
using Infrastructure.ECS;
using Zenject;
using Transform = UnityEngine.Transform;

namespace Feature.HUD.Factory
{
	public sealed class HudFactory : IHudFactory
	{
		[Inject] IFactoryKit _kit;
		[Inject] EntityWrapper _hudRootEntity;

		public int CreateHudRoot()
		{
			var hudRoot = _kit.AssetProvider.HudRoot();
			var instance = _kit.InstantiateService.Instantiate(hudRoot);
			var entity = _kit.EntityBehaviourFactory.InitEntityBehaviour(instance);
			_hudRootEntity.SetEntity(entity);

			var transform = instance.GetComponent<Transform>();
			_hudRootEntity
				.Add<HudRoot>()
				.Add<Common.Component.TransformComponent>()
				.With(e => e.SetTransform(transform))
				;
			return entity;
		}

		public void CreateEventSystem()
		{
			var prefab = _kit.AssetProvider.EventSystem();
			_kit.InstantiateService.Instantiate(prefab);
		}
	}
}