using PongGame.Components;
using PongGame.GameObjects;

namespace PongGame.Systems
{
    internal class SystemPhysics : IUpdateSystems
    {
        public string Name => "SystemPhysics";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_PHYSICS;

        public void OnAction(Entity entity, float dt)
        {
            throw new System.NotImplementedException();
        }
    }
}