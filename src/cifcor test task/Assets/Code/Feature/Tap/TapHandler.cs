using Feature.Tap.Factory;
using Feature.Tap.TapProcessor;
using Input.Character;
using UnityEngine;
using Zenject;

namespace Feature.Tap
{
	public sealed class TapHandler : MonoBehaviour
	{
		[Inject] ITouch _touch;
		[Inject] Camera _camera;
		[Inject] ITapFactory _tapFactory;
		[Inject] ITapProcessor _tapProcessor;
		
		void Awake()
		{
			_touch.Taped += OnTaped;
		}

		void OnDestroy()
		{
			_touch.Taped -= OnTaped;
		}

		void OnTaped(Vector2 screenPos)
		{
			var ray = _camera.ScreenPointToRay(screenPos);
			var hit = Physics2D.GetRayIntersection(ray);

			if (IsCanTap(hit, out var tapTarget) == false)
				return;

			if (TryMakeTap(out var accruedCurrency) == false)
				return;

			_tapFactory.CreateTapFX(hit.point, tapTarget.transform, accruedCurrency);
		}

		bool TryMakeTap(out int accruedCurrency)
		{
			if (_tapProcessor.IsCanTap() == false)
			{
				accruedCurrency = default;
				return false;
			}

			accruedCurrency = _tapProcessor.ProcessTap();
			return true;
		}

		bool IsCanTap(RaycastHit2D hit, out ITapTarget tapTarget)
		{
			tapTarget = default;

			if (hit.collider == null)
				return false;

			var rb = hit.rigidbody;
			if (rb == null)
				return false;

			if (rb.TryGetComponent<ITapTarget>(out tapTarget) == false)
				return false;

			return true;
		}
	}
}