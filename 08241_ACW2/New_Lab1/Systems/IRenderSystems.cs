using PongGame.Managers;

namespace PongGame.Systems
{
    internal interface IRenderSystems
    {
        void OnAction(EntityManager entityManager);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}