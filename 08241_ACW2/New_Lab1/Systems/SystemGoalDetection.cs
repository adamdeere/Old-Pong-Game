using OpenTK;
using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemGoalDetection : IUpdateSystems
    {
        public string Name => "SystemGoalDetection";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_PHYSICS;

        private Vector2 pos;

        public SystemGoalDetection()
        {
            float x = (int)(SceneManager.WindowWidth * 0.5);
            float y = (int)(SceneManager.WindowHeight * 0.5);
            pos = new Vector2(x, y);
        }

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

                    // AI side
                    if (position.X < 0)
                    {
                        ResetBall(transform, physics);
                        AddScore(entityManager.FindEntity("PaddleTwo"));
                    }
                    // Player side
                    else if (position.X > SceneManager.WindowWidth)
                    {
                        ResetBall(transform, physics);
                        AddScore(entityManager.FindEntity("PaddleOne"));
                    }
                }
            }
        }

        private void AddScore(Entity entity)
        {
            List<IComponent> components = entity.Components;
            IComponent scoreComponent = components.Find(delegate (IComponent component)
            {
                return component.ComponentType == ComponentTypes.COMPONENT_SCORE_DATA;
            });
            ComponentScoreData score = ((ComponentScoreData)scoreComponent);
            score.Score++;
        }

        private void ResetBall(ComponentTransform transform, ComponentPhysics physics)
        {
            transform.Position = pos;
            physics.Velocity = physics.RandomVelocity();
        }
    }
}