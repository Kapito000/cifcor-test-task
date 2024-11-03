using Feature.Energy.Component;
using Feature.Input.Component;
using Gameplay.Collisions;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using StaticData.GameBalance;
using Zenject;

namespace Feature.Tap.System
{
	public sealed class PlayerTapRequestSystem : IEcsRunSystem
	{
		[Inject] IGameBalance _gameBalance;
		[Inject] EntityWrapper _energy;
		[Inject] EntityWrapper _listener;

		readonly EcsFilterInject<Inc<EnergyComponent>> _energyFilter;
		readonly EcsFilterInject<
				Inc<InputListener, TapListener, TapComponent, ScreenPosition>>
			_listenerFilter;

		public void Run(IEcsSystems systems)
		{
			foreach (var listener in _listenerFilter.Value)
			foreach (var energy in _energyFilter.Value)
			{
				_energy.SetEntity(energy);
				var energyValue = _energy.Energy();
				if (energyValue <= 0)
					continue;
				_energy.SetEnergy(energyValue - _gameBalance.TapCost);
				
				_listener.SetEntity(listener);
				_listener.Add<TapRequest>();
			}
		}
	}
}