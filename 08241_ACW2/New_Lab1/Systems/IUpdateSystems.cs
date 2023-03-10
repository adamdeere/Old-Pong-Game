using PongGame.GameObjects;

namespace PongGame.Systems
{
    internal interface IUpdateSystems
    {
        void OnAction(Entity entity, float dt);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}