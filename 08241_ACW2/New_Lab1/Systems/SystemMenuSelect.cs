using OpenTK.Input;
using PongGame.Systems.Interfaces;

namespace PongGame.Systems
{
    internal class SystemMenuSelect : IMenuInputSystems
    {
        public string Name => "SystemMenuSelect";

        public void OnAction(SceneManager sceneManager, KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Key.Number1))
            {
                sceneManager.StartNewGame();
            }
        }
    }
}