using PongGame.Components;

namespace PongGame.GameObjects
{
    internal class PlayerTwoPaddle : GameObject
    {
        public PlayerTwoPaddle(string name, int paddle)
            : base(name)
        {
            AddComponent(new ComponentModel(paddle));
            AddComponent(new ComponentTransform(SceneManager.WindowWidth - 40, (int)(SceneManager.WindowHeight * 0.5)));
            AddComponent(new ComponentSecondInput(100));
            AddComponent(new ComponentScoreData("Player", 400f));
        }
    }
}