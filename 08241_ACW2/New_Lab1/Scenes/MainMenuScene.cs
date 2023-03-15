using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.Managers;
using PongGame.Scenes;
using PongGame.Systems;
using PongGame.Systems.MenuSystems;
using System;

namespace PongGame
{
    internal class MainMenuScene : ISceneRefactor
    {
        private SystemManager m_SystemManager;
        private EntityManager m_EntityManager;

        public MainMenuScene()
        {
            m_SystemManager = new SystemManager();
            m_EntityManager = new EntityManager();
            m_SystemManager.AddInputSystem(new SystemMenuSelect());
            m_SystemManager.AddRenderSystem(new SystemRenderMenu());
        }

        public void Load(EventArgs e)
        {
            
        }

        public void Update(FrameEventArgs e)
        {
            m_SystemManager.ActionInputSystems(Keyboard.GetState());
        }

        public void Render(FrameEventArgs e)
        {
            int width = SceneManager.WindowWidth;
            int height = SceneManager.WindowHeight;
            GL.Viewport(0, 0, width, height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, width, 0, height, -1, 1);
            m_SystemManager.ActionRenderSystems(m_EntityManager);
        }
    }
}