using OpenTK;
using PongGame.Components;
using PongGame.Managers;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemPhysics : IUpdateSystems
    {
        public string Name => "SystemPhysics";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_PHYSICS;

        public void OnAction(EntityManager entityManager, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent transformComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    ComponentTransform transform = transformComponent as ComponentTransform;

                    Vector2 position = transform.Position;

                    IComponent physicsComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_PHYSICS;
                    });

                    ComponentPhysics physics = physicsComponent as ComponentPhysics;

                    transform.Position = Update(position, physics, dt);
                }
            }
        }

        private Vector2 UpdateVelocity(Vector2 velocity)
        {
            velocity.Y *= -1.0f;
            return velocity;
        }

        private Vector2 Update(Vector2 position, ComponentPhysics physics, float dt)
        {
            Vector2 velocity = physics.Velocity;
            position += velocity * dt;

            if (position.Y < 0.0f)
            {
                position.Y = 1.0f;
                physics.Velocity = UpdateVelocity(velocity);
            }
            else if (position.Y > SceneManager.WindowHeight)
            {
                position.Y = SceneManager.WindowHeight - 1.0f;
                physics.Velocity = UpdateVelocity(velocity);
            }
            return position;
        }
    }
}