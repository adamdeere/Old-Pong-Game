using OpenTK;
using OpenTK.Input;
using PongGame.Components;
using PongGame.Managers;
using PongGame.Systems.Interfaces;

namespace PongGame.Systems.GameSystems
{
    internal class SystemPlayerInput : IControllerInputSystems
    {
        public string Name => "SystemPlayerInput";

        private const ComponentTypes MASK =
             ComponentTypes.COMPONENT_INPUT;

        public void OnAction(EntityManager entityManager, KeyboardState keyState, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    if (entity.FindComponent(ComponentTypes.COMPONENT_INPUT) is ComponentInput input
                     && entity.FindComponent(ComponentTypes.COMPONENT_TRANSFORM) is ComponentTransform transform)
                    {
                        Vector2 pos = transform.Position;
                        if (keyState.IsKeyDown(Key.W))
                        {
                            pos.Y += input.Speed * dt;
                        }
                        if (keyState.IsKeyDown(Key.S))
                        {
                            pos.Y -= input.Speed * dt;
                        }
                        transform.Position = pos;
                    }
                }
            }
        }
    }
}