using OpenTK;
using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;

namespace PongGame.Systems
{
    internal class SystemAI : IUpdateSystems
    {
        public string Name => "SystemAI";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_AI;

        private Vector2 m_Velocity;

        public void OnAction(EntityManager entityManager, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    Entity ball = entityManager.FindEntity("Ball");

                    ComponentTransform transform = entity.FindComponent(ComponentTypes.COMPONENT_TRANSFORM) as ComponentTransform;
                    ComponentTransform ballTransform = ball.FindComponent(ComponentTypes.COMPONENT_TRANSFORM) as ComponentTransform;

                    Vector2 position = transform.Position;
                    Vector2 ballPosition = ballTransform.Position;
                    m_Velocity.Y = (ballPosition.Y - position.Y) * dt;
                    transform.Position += m_Velocity;
                }
            }
        }
    }
}