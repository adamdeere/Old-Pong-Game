using OpenTK;
using PongGame.Components;
using PongGame.GameObjects;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemPhysics : IUpdateSystems
    {
        public string Name => "SystemPhysics";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_PHYSICS;

        public void OnAction(Entity entity, float dt)
        {
            if ((entity.Mask & MASK) == MASK)
            {
                List<IComponent> components = entity.Components;

                IComponent transformComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                });
                ComponentTransform trans = ((ComponentTransform)transformComponent);

                Vector2 position = trans.Position;

                IComponent physicsComponent = components.Find(delegate (IComponent component)
                {
                    return component.ComponentType == ComponentTypes.COMPONENT_PHYSICS;
                });

                Vector2 velocity = ((ComponentPhysics)physicsComponent).Velocity;

                trans.Position = Update(position, velocity, dt);
            }
        }

        private Vector2 Update(Vector2 position, Vector2 velocity, float dt)
        {
            position += velocity * dt;

            if (position.Y < 0.0f)
            {
                position.Y = 1.0f;
                velocity.Y *= -1.0f;
            }
            else if (position.Y > SceneManager.WindowHeight)
            {
                position.Y = SceneManager.WindowHeight - 1.0f;
                velocity.Y *= -1.0f;
            }

            return position;
        }
    }
}