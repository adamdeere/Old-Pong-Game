﻿using PongGame.Components;
using PongGame.GameObjects;

namespace PongGame
{
    internal class PlayerPaddle : GameObject
    {
        public PlayerPaddle(string name, int paddle)
            : base(name)
        {
            AddComponent(new ComponentModel(paddle));
            AddComponent(new ComponentTransform(40, (int)(Game.WindowHeight * 0.5)));
            AddComponent(new ComponentInput(100));
            AddComponent(new ComponentScoreData("Player One", 400f));
        }
    }
}