﻿using Factory.SystemFactory;
using Feature.Input.System;

namespace Feature.Input
{
	public sealed class InputFeature : Infrastructure.ECS.Feature
	{
		public InputFeature(ISystemFactory systemFactory) : base(systemFactory)
		{
			AddInit<TapSystem>();
			AddCleanup<TapCleanupSystem>();
		}
	}
}