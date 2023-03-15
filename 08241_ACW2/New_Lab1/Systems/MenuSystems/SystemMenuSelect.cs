using OpenTK.Input;
using PongGame.Managers;
using PongGame.Scenes;
using PongGame.Systems.Interfaces;

namespace PongGame.Systems
{
    internal class SystemMenuSelect : IMenuInputSystems
    {
        public string Name => "SystemMenuSelect";

        public void OnAction(KeyboardState keyState)
        {
            if (keyState.IsKeyDown(Key.Number1))
            {
                SceneManager.ChangeScene(new GameScene());
            }
            else if (keyState.IsKeyDown(Key.Number2))
            {
                SceneManager.ChangeScene(new LocalMultiPlayerScene());
            }
            else if (keyState.IsKeyDown(Key.Number3))
            {
                SceneManager.ChangeScene(new HostGameScene());
            }
            else if (keyState.IsKeyDown(Key.Number4))
            {
                SceneManager.ChangeScene(new JoinGameScene());
            }
            else if (keyState.IsKeyDown(Key.Number5))
            {
                SceneManager.ChangeScene(new HighScoreScene());
            }
        }
    }
}