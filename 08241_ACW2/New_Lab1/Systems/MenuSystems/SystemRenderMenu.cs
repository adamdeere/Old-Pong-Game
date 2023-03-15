using PongGame.Managers;
using PongGame.Utility;

namespace PongGame.Systems.MenuSystems
{
    internal class SystemRenderMenu : IRenderSystems
    {
        public string Name => "SystemRenderMenu";

        private RenderText m_RenderText;

        public SystemRenderMenu()
        {
            m_RenderText = new RenderText(SceneManager.WindowWidth, SceneManager.WindowHeight);
        }

        public void OnAction(EntityManager entityManager)
        {
            if (m_RenderText.BMP != null)
            {
                m_RenderText.RenderTextOnScreen("welcome to pong", 0f, 0f);
                m_RenderText.RenderTextOnScreen("1. single player game", 0f, 40f);
                m_RenderText.RenderTextOnScreen("2. multyplayer game", 0f, 80f);
                m_RenderText.RenderTextOnScreen("3. host networked game", 0f, 140f);
                m_RenderText.RenderTextOnScreen("4 connect to networked game", 0f, 180f);
                m_RenderText.RenderTextOnScreen("5. display high scores", 0, 220f);
            }
        }
    }
}