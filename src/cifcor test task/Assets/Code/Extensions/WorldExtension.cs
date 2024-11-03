using Common.Component;
using Infrastructure.ECS;
using Leopotam.EcsLite;
using UnityEngine;

namespace Extensions
{
	public static class WorldExtension
	{
		public static void AddView(this EcsWorld world, int e,
			IEntityView entityView)
		{
			ref var view = ref world.AddComponent<View>(e);
			view.Value = entityView;
		}

		public static void DestroyImmediate(this EcsWorld world, int e)
		{
			var viewPool = world.GetPool<View>();
			if (viewPool.Has(e))
			{
				ref var view = ref world.Get<View>(e);
				Object.Destroy(view.Value.gameObject);
			}
			world.DelEntity(e);
		}

		public static Transform Transform(this EcsWorld world, int e)
		{
			ref var transform = ref world.GetPool<TransformComponent>().Get(e);
			return transform.Value;
		}

		public static Vector3 TransformPos(this EcsWorld world, int e)
		{
			ref var transform = ref world.GetPool<TransformComponent>().Get(e);
			return transform.Value.position;
		}

		public static void SetTransform(this EcsWorld world, int e,
			UnityEngine.Transform transform)
		{
			ref var transformComponent = ref world.GetPool<TransformComponent>().Get(e);
			transformComponent.Value = transform;
		}

		public static void SetMovementDirection(this EcsWorld world, int e,
			Vector2 value)
		{
			ref var movableDirection = ref world.GetPool<MovementDirection>().Get(e);
			movableDirection.Value = value;
		}

		public static ref TComponent AddComponent<TComponent>(this EcsWorld world,
			int e)
			where TComponent : struct =>
			ref world.GetPool<TComponent>().Add(e);

		public static ref TComponent Replace<TComponent>(this EcsWorld world, int e)
			where TComponent : struct
		{
			var pool = world.GetPool<TComponent>();
			if (pool.Has(e))
				return ref pool.Get(e);

			return ref pool.Add(e);
		}

		public static void Remove<TComponent>(this EcsWorld world, int e)
			where TComponent : struct =>
			world.GetPool<TComponent>().Del(e);

		public static ref TComponent Get<TComponent>(this EcsWorld world, int e)
			where TComponent : struct =>
			ref world.GetPool<TComponent>().Get(e);

		public static bool Has<TComponent>(this EcsWorld world, int e)
			where TComponent : struct =>
			world.GetPool<TComponent>().Has(e);

		public static bool Has(this IEcsPool pool, int e) =>
			pool.Has(e);
	}
}