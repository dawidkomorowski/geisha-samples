﻿using Geisha.Common.Math;
using Geisha.Engine.Core.Components;

namespace FlappyBird
{
    public sealed class PipeScrollingComponent : BehaviorComponent
    {
        private const double Speed = 5;

        public override void OnFixedUpdate()
        {
            if (ShouldScroll())
            {
                var transformComponent = Entity.GetComponent<TransformComponent>();
                transformComponent.Translation -= new Vector3(Speed, 0, 0);

                if (transformComponent.Translation.X < -1000)
                {
                    Entity.Destroy();
                }
            }
        }

        private bool ShouldScroll()
        {
            return GlobalGameState.CurrentPhase == GlobalGameState.Phase.WaitingForPlayer || GlobalGameState.CurrentPhase == GlobalGameState.Phase.Playing;
        }
    }
}