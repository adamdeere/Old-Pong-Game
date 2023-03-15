namespace PongGame
{
    public class Start
    {
        public static void Main(string[] args)
        {
            using (Game sceneManager = new Game())
            {
                sceneManager.Run(60.0f);
            }
        }
    }
}