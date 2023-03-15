using OpenTK.Input;
using PongGame.Managers;

namespace PongGame.Systems.Interfaces
{
    internal interface IControllerInputSystems
    {
        void OnAction(EntityManager sceneManager, KeyboardState keyState, float dt);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}