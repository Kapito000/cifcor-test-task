using System;
using Infrastructure.ECS;
using UnityEngine;

namespace Common.Component
{
	[Serializable] public struct TransformComponent { public Transform Value; }
	[Serializable] public struct Rigidbody2DComponent { public Rigidbody2D Value; }
	
	public struct View { public IEntityView Value; }
	
	public struct MovementDirection { public Vector2 Value; }
	public struct Position { public Vector3 Value; }
	public struct Direction { public Vector2 Value; }
	public struct FirstBreath { }
	public struct ForParent { public Transform Value; }
}