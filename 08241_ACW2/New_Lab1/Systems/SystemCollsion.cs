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
                    Entity ball = entityManager.FindEntity("Ball");
                }
            }
        }
    }
}