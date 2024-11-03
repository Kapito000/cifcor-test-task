using Factory;

namespace Feature.Tap.Factory
{
	public interface ITapFactory : IFactory
	{
		int CreateTapHandler();
		int CreateTapTarget();
	}
}