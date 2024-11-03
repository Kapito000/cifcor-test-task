using Common.Component;
using Feature.Input.Component;
using Feature.Tap.Component;
using Gameplay.Collisions;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class TapSystem : IEcsRunSystem
	{
		[Inject] EntityWrapper _camera;
		[Inject] EntityWrapper _tapTarget;
		[Inject] EntityWrapper _listener;
		[Inject] ICollisionRegistry _collisionRegistry;

		readonly EcsFilterInject<Inc<CameraComponent>> _cameraFilter;
		readonly EcsFilterInject<
				Inc<InputListener, TapListener, Input.Component.Tap, ScreenPosition>>
			_listenerFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var listener in _listenerFilter.Value)
			foreach (var cameraEntity in _cameraFilter.Value)
			{
				_camera.SetEntity(cameraEntity);
				_listener.SetEntity(listener);
				var screenPos = _listener.ScreenPosition();

				var hit = Hit(screenPos);
				if (hit.collider == null)
					continue;

				if (TryGetTapTarget(in hit, out var tapTarget) == false)
					continue;

				_tapTarget.SetEntity(tapTarget);
				if (_tapTarget.Has<TapTarget>() == false)
					continue;
				_tapTarget.Replace<Taped>();
			}
		}

		bool TryGetTapTarget(in RaycastHit2D hit, out int tapTarget)
		{
			var instanceID = hit.collider.GetInstanceID();
			return _collisionRegistry.TryGet(instanceID, out tapTarget);
		}

		RaycastHit2D Hit(Vector2 screenPos)
		{
			Camera camera = _camera.Camera();
			var ray = camera.ScreenPointToRay(screenPos);
			var hit = Physics2D.GetRayIntersection(ray);
			return hit;
		}
	}
}