﻿using System.Diagnostics;
using Geisha.Common.Math;
using Geisha.Engine.Core.Components;
using Geisha.Engine.Rendering.Components;

namespace FlappyBird.Components
{
    public sealed class GameOverVfxComponent : BehaviorComponent
    {
        private RectangleRendererComponent _rectangleRendererComponent = null!;
        private const int AnimationTime = 20;
        private int _updateCounter;

        public override void OnStart()
        {
            Debug.Assert(Entity != null, nameof(Entity) + " != null");
            _rectangleRendererComponent = Entity.GetComponent<RectangleRendererComponent>();
        }

        public override void OnFixedUpdate()
        {
            _updateCounter++;

            const int halfOfAnimationTime = AnimationTime / 2;

            if (_updateCounter < halfOfAnimationTime)
            {
                SetAlpha((double) _updateCounter / halfOfAnimationTime);
            }
            else
            {
                SetAlpha(2d - (double) _updateCounter / halfOfAnimationTime);
            }


            if (_updateCounter > AnimationTime)
            {
                Debug.Assert(Entity != null, nameof(Entity) + " != null");
                Entity.DestroyAfterFullFrame();
            }
        }

        private void SetAlpha(double alpha)
        {
            var previousColor = _rectangleRendererComponent.Color;
            _rectangleRendererComponent.Color = Color.FromArgb(alpha, previousColor.DoubleR, previousColor.DoubleG, previousColor.DoubleB);
        }
    }
}