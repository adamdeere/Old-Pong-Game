using PongGame.Managers;

namespace PongGame.Systems
{
    internal interface IUpdateSystems
    {
        void OnAction(EntityManager entity, float dt);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}