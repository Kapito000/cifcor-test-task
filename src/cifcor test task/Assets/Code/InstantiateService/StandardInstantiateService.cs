﻿using Unity.Mathematics;
using UnityEngine;
using Zenject;

namespace InstantiateService
{
	public sealed class StandardInstantiateService : IInstantiateService
	{
		[Inject] DiContainer _container;

		public TComponent Instantiate<TComponent>(Object prefab)
			where TComponent : Component =>
			_container.InstantiatePrefabForComponent<TComponent>(prefab);

		public TComponent Instantiate<TComponent>(Object prefab, Vector3 pos)
			where TComponent : Component
		{
			return _container
				.InstantiatePrefabForComponent<TComponent>(
					prefab, pos, quaternion.identity, null);
		}

		public TComponent Instantiate<TComponent>(TComponent prefab, Vector2 pos, Transform parent)
			where TComponent : Component
		{
			return _container
				.InstantiatePrefabForComponent<TComponent>(
					prefab, pos, quaternion.identity, parent);
		}


		public GameObject Instantiate(Object prefab)
		{
			var instance = _container.InstantiatePrefab(prefab);
			return instance;
		}

		public GameObject Instantiate(Object prefab, Transform parent)
		{
			return _container.InstantiatePrefab(prefab, parent);
		}

		public GameObject Instantiate(GameObject prefab, Vector2 pos,
			Transform parent) =>
			Instantiate(prefab, pos, quaternion.identity, parent);

		public GameObject Instantiate(GameObject prefab,
			Vector2 pos = new(), Quaternion rot = new(),
			Transform parent = null)
		{
			var instance = _container
				.InstantiatePrefab(prefab, pos, rot, parent);
			return instance;
		}

		public TComponent AddComponent<TComponent>(GameObject instance)
			where TComponent : Component
		{
			return _container.InstantiateComponent<TComponent>(instance);
		}
	}
}