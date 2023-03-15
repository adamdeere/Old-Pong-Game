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
       
        private readonly RenderText m_RenderText;

        public SystemGameManager(RenderText renderText)
        {
            m_RenderText = renderText;
        }

        public void OnAction(EntityManager entityManager, float dt)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    if (entity.FindComponent(ComponentTypes.COMPONENT_GAME_MANAGER) is ComponentGameData data)
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
                            SceneManagerRefactor.ChangeScene(new MainMenuScene());
                        }
                    }
                }
            }
        }
    }
}