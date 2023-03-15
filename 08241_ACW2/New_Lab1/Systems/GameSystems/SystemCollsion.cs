using OpenTK;
using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;

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
                    ComponentTransform ballTransform = entity.FindComponent(ComponentTypes.COMPONENT_TRANSFORM) as ComponentTransform;

                    ComponentPhysics ballPhysics = entity.FindComponent(ComponentTypes.COMPONENT_PHYSICS) as ComponentPhysics;

                    ComponentTransform paddleTwoTransform = GetPaddleTransform(entityManager, "PaddleTwo");
                    ComponentTransform paddlePlayerTrans = GetPaddleTransform(entityManager, "PaddleOne");

                    CollsionReaction(paddleTwoTransform, paddlePlayerTrans, ballPhysics, ballTransform, 10);
                }
            }
        }

        private ComponentTransform GetPaddleTransform(EntityManager entityManager, string name)
        {
            GameObject paddle = entityManager.FindEntity(name);

            return paddle.FindComponent(ComponentTypes.COMPONENT_TRANSFORM) as ComponentTransform;
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