using OpenTK;
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
                    List<IComponent> components = entity.Components;

                    IComponent transformComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    ComponentTransform ballTransform = transformComponent as ComponentTransform;
                    IComponent physicsComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_PHYSICS;
                    });

                    ComponentPhysics ballPhysics = physicsComponent as ComponentPhysics;

                    Entity paddleTwo = entityManager.FindEntity("PaddleTwo");
                    Entity paddlePlayer = entityManager.FindEntity("PaddleOne");

                    List<IComponent> playerTwoList = paddleTwo.Components;

                    IComponent paddletwoTransform = playerTwoList.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });

                    ComponentTransform paddleTwoTransform = paddletwoTransform as ComponentTransform;

                    List<IComponent> playerOneList = paddlePlayer.Components;
                    IComponent paddleOneTransform = playerOneList.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });

                    ComponentTransform paddlePlayerTrans = paddleOneTransform as ComponentTransform;
                    CollsionReaction(paddleTwoTransform, paddlePlayerTrans, ballPhysics, ballTransform, 10);
                }
            }
        }

        private void CollsionReaction(ComponentTransform paddleAI, ComponentTransform paddlePlayer, ComponentPhysics ball, ComponentTransform ballPos, int ballRadius)
        {
            // PaddleTwo
            if ((paddleAI.Position.X - ballPos.Position.X) < ballRadius &&
               ballPos.Position.Y > (paddleAI.Position.Y - 35.0f) &&
               ballPos.Position.Y < (paddleAI.Position.Y + 35.0f))
            {
                ballPos.Position = new Vector2(paddleAI.Position.X - ballRadius, ballPos.Position.Y);
                ball.Velocity = new Vector2(ball.Velocity.X * -1.0f, ball.Velocity.Y) * 2.0f;
            }
            // PaddleOne
            if ((ballPos.Position.X - paddlePlayer.Position.X) < ballRadius &&
               ballPos.Position.Y > (paddlePlayer.Position.Y - 35.0f) &&
               ballPos.Position.Y < (paddlePlayer.Position.Y + 35.0f))
            {
                ballPos.Position = new Vector2(paddlePlayer.Position.X + ballRadius, ballPos.Position.Y);
                ball.Velocity = new Vector2(ball.Velocity.X * -1.0f, ball.Velocity.Y) * 2.0f;
            }
        }
    }
}