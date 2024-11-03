using System;
using UnityEngine;

namespace Input.Character
{
	public interface ITouch : IInput
	{
		event Action<Vector2> Taped;
	}
}