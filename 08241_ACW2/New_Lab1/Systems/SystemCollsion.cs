using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemCollsion : IUpdateSystems
    {
        public string Name => "SystemCollsion";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_COLISION;

        public void OnAction(EntityManager entityManager, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    Entity ball = entityManager.FindEntity("Ball");
                    // Get components from the ball
                    List<IComponent> ballComponents = ball.Components;

                    IComponent ballTransformComponent = ballComponents.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    ComponentTransform ballTransform = ballTransformComponent as ComponentTransform;

                    IComponent ballCollsionComponent = ballComponents.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_BALL_COLLSION;
                    });
                    ComponentBallCollsion ballCollsion = ballCollsionComponent as ComponentBallCollsion;

                    // get components of the paddle
                    List<IComponent> components = entity.Components;

                    IComponent paddleTransformComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    ComponentTransform paddleTransform = ballTransformComponent as ComponentTransform;
                }
            }
        }
    }
}