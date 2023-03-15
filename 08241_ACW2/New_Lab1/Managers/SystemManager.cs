using OpenTK.Input;
using PongGame.Systems;
using PongGame.Systems.Interfaces;
using System.Collections.Generic;

namespace PongGame.Managers
{
    internal class SystemManager
    {
        private readonly List<IRenderSystems> m_RenderSystems;
        private readonly List<IUpdateSystems> m_UpdateSystems;
        private readonly List<IMenuInputSystems> m_InputSystems;
        private readonly SceneManager m_SceneManager;

        public SystemManager()
        {
            m_RenderSystems = new List<IRenderSystems>();
            m_UpdateSystems = new List<IUpdateSystems>();
            m_InputSystems = new List<IMenuInputSystems>();
        }

        public SystemManager(SceneManager sceneManager)
        {
            m_SceneManager = sceneManager;
            m_RenderSystems = new List<IRenderSystems>();
            m_UpdateSystems = new List<IUpdateSystems>();
            m_InputSystems = new List<IMenuInputSystems>();
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

        public void ActionInputSystems(SceneManager sceneManager, KeyboardState state)
        {
            foreach (var system in m_InputSystems)
            {
                system.OnAction(sceneManager, state);
            }
        }

        public void AddInputSystem(IMenuInputSystems system)
        {
            // IUpdateSystem result = FindUpdateSystem(system.Name);
            // Debug.Assert(result != null, "System '" + system.Name + "' already exists");
            m_InputSystems.Add(system);
        }
    }
}