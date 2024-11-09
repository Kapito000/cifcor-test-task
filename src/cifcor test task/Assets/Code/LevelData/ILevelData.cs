using Infrastructure;
using Infrastructure.Boot;
using Infrastructure.ECS;

namespace LevelData
{
	public interface ILevelData : IService
	{
		IDevSceneRunner DevSceneRunner { get; set; }
	}
}