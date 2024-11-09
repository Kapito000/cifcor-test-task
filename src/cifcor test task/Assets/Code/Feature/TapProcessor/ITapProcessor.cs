using Infrastructure;

namespace Feature.TapProcessor
{
	internal interface ITapProcessor : IService
	{
		int ProcessTap();
		bool IsCanTap();
	}
}