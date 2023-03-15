using OpenTK.Input;

namespace PongGame.Systems.Interfaces
{
    internal interface IMenuInputSystems
    {
        void OnAction(KeyboardState keyState);

        // Property signatures:
        string Name
        {
            get;
        }
    }
}