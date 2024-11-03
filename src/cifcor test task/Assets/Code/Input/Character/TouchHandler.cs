using System;
using UnityEngine;
using UnityEngine.InputSystem;
using Zenject;

namespace Input.Character
{
	public sealed class TouchHandler : ITouch, IDisposable
	{
		[Inject] Controls _controls;
		
		Vector2 _screenPos;

		public event Action<Vector2> Taped;

		[Inject]
		void Construct()
		{
			_controls.Touch.Tap.performed += OnTapPerformed;
			_controls.Touch.ScreenPos.performed += OnScreenPosChanged;
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
			_controls.Touch.ScreenPos.performed -= OnScreenPosChanged;
		}

		void OnScreenPosChanged(InputAction.CallbackContext context)
		{
			_screenPos = context.ReadValue<Vector2>();
		}
		
		void OnTapPerformed(InputAction.CallbackContext context)
		{
			Taped?.Invoke(_screenPos);
		}
	}
}