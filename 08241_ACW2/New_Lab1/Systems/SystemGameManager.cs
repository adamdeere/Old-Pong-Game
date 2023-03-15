using PongGame.Components;
using PongGame.Managers;
using PongGame.Utility;
using System;

namespace PongGame.Systems
{
    internal class SystemGameManager : IUpdateSystems
    {
        public string Name => "SystemGameManager";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_GAME_MANAGER;

        private readonly SceneManager m_SceneManager;
        private readonly RenderText m_RenderText;

        public SystemGameManager(SceneManager sceneManager, RenderText renderText)
        {
            m_SceneManager = sceneManager;
            m_RenderText = renderText;
        }

        public void OnAction(EntityManager entityManager, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    ComponentGameData data = entity.FindComponent(ComponentTypes.COMPONENT_GAME_MANAGER) as ComponentGameData;

                    if (data != null)
                    {
                        double gameTime = data.GameTime;
                        if (gameTime > 0)
                        {
                            string time = "Time remaining: " + Math.Truncate(gameTime);
                            m_RenderText.RenderTextOnScreen(time, 0, 0);

                            data.GameTime -= 1.0 * dt;
                        }
                        else
                        {
                            m_SceneManager.StartMenu();
                        }
                    }
                }
            }
        }
    }
}