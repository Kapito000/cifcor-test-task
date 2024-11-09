using System;
using Infrastructure;

namespace Feature.Tap.TapProcessor
{
	internal interface ITapProcessor : IService
	{
		int ProcessTap();
		bool IsCanTap();
		event Action<int> AccrualCalculated;
	}
}