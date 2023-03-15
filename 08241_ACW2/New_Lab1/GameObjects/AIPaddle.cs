using PongGame.Components;
using PongGame.GameObjects;

namespace PongGame
{
    internal class AIPaddle : GameObject
    {
        public AIPaddle(string name, int paddle)
            : base(name)
        {
            AddComponent(new ComponentModel(paddle));
            AddComponent(new ComponentTransform(Game.WindowWidth - 40, (int)(Game.WindowHeight * 0.5)));
            AddComponent(new ComponentAI());
            AddComponent(new ComponentScoreData("AI", 700f));
        }
    }
}