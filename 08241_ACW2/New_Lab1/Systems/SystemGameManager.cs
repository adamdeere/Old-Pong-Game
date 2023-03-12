using OpenTK;
using PongGame.Components;
using PongGame.Managers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PongGame.Systems
{
    internal class SystemGameManager : IUpdateSystems
    {
        public string Name => "SystemGameManager";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_GAME_MANAGER;
        private SceneManager m_SceneManager;
        public SystemGameManager(SceneManager sceneManager)
        {
            m_SceneManager = sceneManager;  
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
                            m_SceneManager.Title = "time remaining " + Math.Truncate(gameTime);
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
