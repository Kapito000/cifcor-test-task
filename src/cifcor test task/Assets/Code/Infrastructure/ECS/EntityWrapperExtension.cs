using Common.Component;
using Extensions;
using Feature.Energy.Component;
using Feature.Input.Component;
using Feature.Tap.Component;
using Feature.Wallet.Component;
using Leopotam.EcsLite;
using UnityEngine;
using Rigidbody2D = UnityEngine.Rigidbody2D;
using Transform = UnityEngine.Transform;

namespace Infrastructure.ECS
{
	public partial class EntityWrapper
	{
		public EcsWorld World() => _world;

		public Transform Transform() =>
			_world.Transform(_entity);

		public Vector3 TransformPos() =>
			_world.TransformPos(_entity);

		public EntityWrapper SetTransform(Transform transform)
		{
			_world.SetTransform(_entity, transform);
			return this;
		}

		public void SetRigidbody2DVelocity(Vector2 velocity)
		{
			var rb = Rigidbody2D();
			rb.velocity = velocity;
		}

		public Rigidbody2D Rigidbody2D()
		{
			ref var rigidbody2D = ref _world
				.GetPool<Common.Component.Rigidbody2DComponent>()
				.Get(_entity);

			return rigidbody2D.Value;
		}

		public Vector2 MoveDirection()
		{
			ref var moveDirection =
				ref _world.GetPool<MovementDirection>().Get(_entity);
			return moveDirection.Value;
		}

		public IEntityView View()
		{
			ref var view = ref Get<View>();
			return view.Value;
		}

		public Vector3 Position()
		{
			ref var position = ref _world.GetPool<Position>().Get(_entity);
			return position.Value;
		}

		public void SetPosition(Vector2 pos)
		{
			ref var position = ref Get<Position>();
			position.Value = pos;
		}

		public Vector2 Direction()
		{
			ref var dir = ref Get<Direction>();
			return dir.Value;
		}

		public EntityWrapper AddDirection(Vector2 dir)
		{
			ref var direction = ref AddComponent<Direction>();
			direction.Value = dir;
			return this;
		}

		public void SetDirection(Vector2 dir)
		{
			ref var direction = ref Get<Direction>();
			direction.Value = dir;
		}

		public Transform ForParent()
		{
			ref var forParent = ref Get<ForParent>();
			return forParent.Value;
		}

		public EntityWrapper AddForParent(Transform parent)
		{
			ref var forParent = ref AddComponent<ForParent>();
			forParent.Value = parent;
			return this;
		}

		public void ReplaceTap(Vector2 screenPos)
		{
			ReplaceComponent<TapComponent>();
			ref var pos = ref ReplaceComponent<ScreenPosition>();
			pos.Value = screenPos;
		}

		public Camera Camera()
		{
			ref var cameraComponent = ref Get<CameraComponent>();
			return cameraComponent.Value;
		}

		public Vector2 ScreenPosition()
		{
			ref var screenPosition = ref Get<ScreenPosition>();
			return screenPosition.Value;
		}

		public void AppendCurrency(int accruals)
		{
			ref var walletCurrency = ref Get<WalletCurrency>();
			walletCurrency.Value += accruals;
		}

		public EntityWrapper ChangeWalletBalanceRequest(int value)
		{
			ref var request = ref ReplaceComponent<ChangeBalanceRequest>();
			request.Value += value;
			return this;
		}

		public EntityWrapper AddEnergy(int value)
		{
			ref var energyComponent = ref AddComponent<EnergyComponent>();
			energyComponent.Value = value;
			return this;
		}

		public EntityWrapper AddMaxEnergy(int value)
		{
			ref var maxEnergy = ref AddComponent<MaxEnergy>();
			maxEnergy.Value = value;
			return this;
		}

		public int Energy()
		{
			ref var energy = ref Get<EnergyComponent>();
			return energy.Value;
		}

		public EntityWrapper SetEnergy(int value)
		{
			ref var energyComponent = ref Get<EnergyComponent>();
			energyComponent.Value = value;
			return this;
		}

		public EntityWrapper AddAutoTapInterval(float value)
		{
			ref var autoTapInterval = ref AddComponent<AutoTapInterval>();
			autoTapInterval.Value = value;
			return this;
		}

		public float AutoTapTimer()
		{
			ref var autoTapTimer = ref Get<AutoTapTimer>();
			return autoTapTimer.Value;
		}

		public EntityWrapper SetAutoTapTimer(float value)
		{
			ref var autoTapTimer = ref Get<AutoTapTimer>();
			autoTapTimer.Value = value;
			return this;
		}

		public float AutoTapInterval()
		{
			ref var autoTapInterval = ref Get<AutoTapInterval>();
			return autoTapInterval.Value;
		}
	}
}