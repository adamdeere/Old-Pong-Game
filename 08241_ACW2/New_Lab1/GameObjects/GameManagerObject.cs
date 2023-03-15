using PongGame.Components;
using PongGame.GameObjects;

namespace PongGame
{
    internal class GameManagerObject : GameObject
    {
        public GameManagerObject(string name, double gameTime)
             : base(name)
        {
            AddComponent(new ComponentGameData(gameTime));
        }
    }
}