namespace PongGame
{
    public class Start
    {
        private static int Port;
        private static string IPaddress;
        private static string masterIp;

        public static void Main(string[] args)
        {
            using (SceneManager sceneManager = new SceneManager())
            {
                sceneManager.Run(60.0f);
            }
        }
    }
}