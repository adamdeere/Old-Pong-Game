using OpenTK.Input;

namespace PongGame.Systems.Interfaces
{
    internal interface IMenuInputSystems
    {
        void OnAction(SceneManager sceneManager, KeyboardState keyState);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}