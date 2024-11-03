using System;
using Feature.Input.Component;
using Infrastructure.ECS;
using Input.Character;
using Leopotam.EcsLite;
using Leopotam.EcsLite.Di;
using UnityEngine;
using Zenject;

namespace Feature.Input.System
{
	public sealed class TapSystem : IEcsInitSystem, IDisposable
	{
		[Inject] ITouch _touch;
		[Inject] EntityWrapper _listener;

		readonly EcsFilterInject<Inc<InputListener, TapListener>> _listenerFilter;

		public void Init(IEcsSystems systems)
		{
			_touch.Taped += OnTaped;
		}

		public void Dispose()
		{
			_touch.Taped -= OnTaped;
		}

		void OnTaped(Vector2 screenPos)
		{
			foreach (var e in _listenerFilter.Value)
			{
				_listener.SetEntity(e);
				_listener.ReplaceTap(screenPos);
			}
		}
	}
}