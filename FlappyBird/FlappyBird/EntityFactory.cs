﻿using System;
using Geisha.Common.Math;
using Geisha.Engine.Core.Assets;
using Geisha.Engine.Core.Components;
using Geisha.Engine.Core.SceneModel;
using Geisha.Engine.Input;
using Geisha.Engine.Input.Components;
using Geisha.Engine.Input.Mapping;
using Geisha.Engine.Rendering;
using Geisha.Engine.Rendering.Components;

namespace FlappyBird
{
    public interface IEntityFactory
    {
        Entity CreateCamera();
        Entity CreateBackgroundDay();
        Entity CreateGround();
        Entity CreateBird();
        Entity CreateGameOver();
    }

    public sealed class EntityFactory : IEntityFactory
    {
        private readonly IAssetStore _assetStore;

        public EntityFactory(IAssetStore assetStore)
        {
            _assetStore = assetStore;
        }

        public Entity CreateCamera()
        {
            var entity = new Entity();
            entity.AddComponent(TransformComponent.Default);
            entity.AddComponent(new CameraComponent());
            return entity;
        }

        public Entity CreateBackgroundDay()
        {
            var entity = new Entity();
            entity.AddComponent(new TransformComponent
            {
                Translation = Vector3.Zero,
                Rotation = Vector3.Zero,
                Scale = new Vector3(2, 2, 1)
            });
            entity.AddComponent(new SpriteRendererComponent
            {
                Sprite = _assetStore.GetAsset<Sprite>(new AssetId(new Guid("01497f1f-7d61-46fa-b2a2-57c152eb88f7"))),
                SortingLayerName = "Background"
            });
            return entity;
        }

        public Entity CreateGround()
        {
            var entity = new Entity();
            entity.AddComponent(TransformComponent.Default);
            entity.AddComponent(new SpriteRendererComponent
            {
                Sprite = _assetStore.GetAsset<Sprite>(new AssetId(new Guid("f0b24406-7fce-43e2-98b0-eb903fbc1e76"))),
                SortingLayerName = "Ground"
            });
            entity.AddComponent(new GroundScrollingComponent());
            return entity;
        }

        public Entity CreateBird()
        {
            var entity = new Entity {Name = "Bird"};
            entity.AddComponent(new TransformComponent
            {
                Translation = Vector3.Zero,
                Rotation = Vector3.Zero,
                Scale = new Vector3(2, 2, 1)
            });
            entity.AddComponent(new SpriteRendererComponent
            {
                Sprite = _assetStore.GetAsset<Sprite>(new AssetId(new Guid("71f76a03-88d4-454c-b372-eaae11fc120f"))),
                SortingLayerName = "Bird"
            });
            entity.AddComponent(new InputComponent
            {
                InputMapping = new InputMapping
                {
                    ActionMappings =
                    {
                        new ActionMapping
                        {
                            ActionName = "Flap",
                            HardwareActions =
                            {
                                new HardwareAction
                                {
                                    HardwareInputVariant = HardwareInputVariant.CreateKeyboardVariant(Key.Space)
                                }
                            }
                        }
                    }
                }
            });
            entity.AddComponent(new BirdIdleFlyingComponent());
            return entity;
        }

        public Entity CreateGameOver()
        {
            var entity = new Entity {Name = "GameOver"};
            entity.AddComponent(new TransformComponent
            {
                Translation = Vector3.Zero,
                Rotation = Vector3.Zero,
                Scale = new Vector3(2, 2, 1)
            });
            entity.AddComponent(new SpriteRendererComponent
            {
                Sprite = _assetStore.GetAsset<Sprite>(new AssetId(new Guid("de7e5788-c21c-4897-b014-c79c41ae39dd"))),
                SortingLayerName = "UI"
            });
            return entity;
        }
    }
}