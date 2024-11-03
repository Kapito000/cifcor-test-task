using Common.Component;
using Feature.Input.Component;
using Feature.Tap.Component;
using Feature.Tap.Factory;
using Feature.Wallet.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class TapFxSystem : IEcsRunSystem
	{
		[Inject] ITapFactory _tapFactory;
		[Inject] EntityWrapper _tap;
		[Inject] EntityWrapper _camera;
		[Inject] EntityWrapper _wallet;

		readonly EcsFilterInject<Inc<CameraComponent>> _cameraFilter;
		readonly EcsFilterInject<Inc<TapTarget, Taped>> _tapTargetFilter;
		readonly EcsFilterInject<Inc<TapComponent, ScreenPosition>> _tapFilter;
		readonly EcsFilterInject<
			Inc<WalletComponent, ChangeBalanceRequest>> _walletFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var tap in _tapFilter.Value)
			foreach (var target in _tapTargetFilter.Value)
			foreach (var cameraEntity in _cameraFilter.Value)
			foreach (var wallet in _walletFilter.Value)
			{
				_tap.SetEntity(tap);
				var screenPosition = _tap.ScreenPosition();

				_camera.SetEntity(cameraEntity);
				var camera = _camera.Camera();
				var spawnPos = camera.ScreenToWorldPoint(screenPosition);
				spawnPos.Scale(new Vector3(1, 1, 0));
				
				_wallet.SetEntity(wallet);
				var value = _wallet.ChangeBalanceRequest();
				
				_tapFactory.CreateTapFX(spawnPos, value);
			}
		}
	}
}