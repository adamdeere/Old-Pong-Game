using PongGame.Systems;
using System.Collections.Generic;

namespace PongGame.Managers
{
    internal class SystemManager
    {
        private readonly List<IRenderSystems> m_RenderSystems;
        private readonly List<IUpdateSystems> m_UpdateSystems;

        public SystemManager()
        {
            m_RenderSystems = new List<IRenderSystems>();
            m_UpdateSystems = new List<IUpdateSystems>();
        }

        public void ActionRenderSystems(EntityManager entityManager)
        {
            foreach (var system in m_RenderSystems)
            {
                system.OnAction(entityManager);
            }
        }

        public void AddRenderSystem(IRenderSystems system)
        {
            //IRenderSystem result = FindSystem(system.Name);
            // Debug.Assert(result != null, "System '" + system.Name + "' already exists");
            m_RenderSystems.Add(system);
        }

        public void ActionUpdateSystems(EntityManager entityManager, float dt)
        {
            foreach (var system in m_UpdateSystems)
            {
                system.OnAction(entityManager, dt);
            }
        }

        public void AddUpdateSystem(IUpdateSystems system)
        {
            // IUpdateSystem result = FindUpdateSystem(system.Name);
            // Debug.Assert(result != null, "System '" + system.Name + "' already exists");
            m_UpdateSystems.Add(system);
        }
    }
}