using Common.Component;
using Feature.Energy.Component;
using Feature.Input.Component;
using Feature.Tap.Component;
using Gameplay.Collisions;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using UnityEngine;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class ProseccTapInputSystem : IEcsRunSystem
	{
		[Inject] IGameBalance _gameBalance;
		[Inject] EntityWrapper _camera;
		[Inject] EntityWrapper _energy;
		[Inject] EntityWrapper _request;
		[Inject] EntityWrapper _tapTarget;
		[Inject] ICollisionRegistry _collisionRegistry;

		readonly EcsFilterInject<Inc<CameraComponent>> _cameraFilter;
		readonly EcsFilterInject<Inc<EnergyComponent>> _energyFilter;
		readonly EcsFilterInject<Inc<TapComponent, ScreenPosition>> _tapRequestFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var request in _tapRequestFilter.Value)
			foreach (var energy in _energyFilter.Value)
			foreach (var camera in _cameraFilter.Value)
			{
				var hit = Hit(request, camera);
				if (hit.collider == null)
					continue;

				if (TryGetTapTarget(in hit, out var tapTarget) == false)
					continue;

				_tapTarget.SetEntity(tapTarget);
				if (_tapTarget.Has<TapTarget>() == false)
					continue;
				
				_energy.SetEntity(energy);
				var energyValue = _energy.Energy();
				if (energyValue <= 0)
					continue;
				_energy.ReplaceChangeEnergyRequest(_gameBalance.TapCost);

				_tapTarget.Replace<Taped>();
			}
		}

		bool TryGetTapTarget(in RaycastHit2D hit, out int tapTarget)
		{
			var instanceID = hit.collider.GetInstanceID();
			return _collisionRegistry.TryGet(instanceID, out tapTarget);
		}

		RaycastHit2D Hit(int request, int cameraEntity)
		{
			_request.SetEntity(request);
			var screenPos = _request.ScreenPosition();

			_camera.SetEntity(cameraEntity);
			Camera camera = _camera.Camera();

			var ray = camera.ScreenPointToRay(screenPos);
			var hit = Physics2D.GetRayIntersection(ray);
			return hit;
		}
	}
}