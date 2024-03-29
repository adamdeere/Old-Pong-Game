﻿using OpenTK.Input;
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
            if (keyState.IsKeyDown(Key.Number2))
            {
                SceneManager.ChangeScene(new LocalMultiPlayerScene());
            }
        }
    }
}