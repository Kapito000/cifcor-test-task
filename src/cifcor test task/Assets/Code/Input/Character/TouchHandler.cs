﻿using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.Character
{
	public sealed class TouchHandler : ITouch, IDisposable
	{
		[Inject] Controls _controls;

		public event Action<Vector2> Taped;

		[Inject]
		void Construct()
		{
			_controls.Touch.Tap.performed += OnTapPerformed;
		}

		public void Enable()
		{
			_controls.Touch.Enable();
		}

		public void Disable()
		{
			_controls.Touch.Disable();
		}

		public void Dispose()
		{
			_controls.Touch.Tap.performed -= OnTapPerformed;
		}

		void OnTapPerformed(InputAction.CallbackContext context)
		{
			var pos = context.ReadValue<Vector2>();
			Taped?.Invoke(pos);
		}
	}
}