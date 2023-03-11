using PongGame.Managers;

namespace PongGame.Systems
{
    internal interface IRenderSystems
    {
        void OnAction(EntityManager entityList);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}