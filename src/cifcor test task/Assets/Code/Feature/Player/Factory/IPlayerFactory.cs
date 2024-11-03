using Factory;

namespace Feature.Player.Factory
{
	public interface IPlayerFactory : IFactory
	{
		int CreatePlayer();
	}
}