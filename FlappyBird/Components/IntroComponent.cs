﻿using System.Diagnostics;
using Geisha.Engine.Core.Components;

namespace FlappyBird.Components
{
    public sealed class IntroComponent : BehaviorComponent
    {
        public override void OnFixedUpdate()
        {
            if (GlobalGameState.CurrentPhase == GlobalGameState.Phase.WaitingForPlayer) return;

            Debug.Assert(Entity != null, nameof(Entity) + " != null");
            Entity.DestroyAfterFullFrame();
        }
    }
}