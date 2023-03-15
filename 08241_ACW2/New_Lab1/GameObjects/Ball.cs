using PongGame.Components;
using PongGame.GameObjects;

namespace PongGame
{
    internal class Ball : GameObject
    {
        public Ball(string name, int ball)
            : base(name)
        {
            AddComponent(new ComponentModel(ball));
            AddComponent(new ComponentTransform((int)(Game.WindowWidth * 0.5), (int)(Game.WindowHeight * 0.5)));
            AddComponent(new ComponentPhysics());
            AddComponent(new ComponentBallCollsion(10));
            AddComponent(new ComponentCollsion());
        }
    }
}