using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.Managers;
using PongGame.Systems;
using PongGame.Systems.MenuSystems;
using PongGame.Utility;
using System;

namespace PongGame
{
    internal class MainMenuScene : Scene, IScene
    {
        private readonly RenderText m_RenderText;
        private SystemManager m_SystemManager;
        private EntityManager m_EntityManager;

        public MainMenuScene(SceneManager sceneManager)
            : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Pong - Main Menu";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
            sceneManager.loader = Load;
            m_RenderText = new RenderText(SceneManager.WindowWidth, SceneManager.WindowHeight);
        }

        public void Load(EventArgs e)
        {
            m_SystemManager = new SystemManager();
            m_EntityManager = new EntityManager();
            m_SystemManager.AddInputSystem(new SystemMenuSelect());
            m_SystemManager.AddRenderSystem(new SystemRenderMenu());
        }

        public void Update(FrameEventArgs e)
        {
            m_SystemManager.ActionInputSystems(sceneManager, Keyboard.GetState());
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);
            m_SystemManager.ActionRenderSystems(m_EntityManager);
        }
    }
}