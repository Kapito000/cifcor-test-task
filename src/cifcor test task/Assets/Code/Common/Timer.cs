using System;

namespace Common
{
	public class Timer
	{
		float _time;
		
		public event Action TimerEnd;

		public void Init(float time) => 
			_time = time;

		public bool Update(float delta)
		{
			_time -= delta;
			if (_time <= 0)
			{
				TimerEnd?.Invoke();
				return true;
			}

			return false;
		}
	}
}