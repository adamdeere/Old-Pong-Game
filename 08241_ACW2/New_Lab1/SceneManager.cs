using OpenTK;
using OpenTK.Graphics.OpenGL;
using PongGame.Utility;
using System;
using System.Collections.Generic;

namespace PongGame
{
    internal class SceneManager : GameWindow
    {
        private Scene scene;
        private static int width = 0;
        private static int height = 0;

        public delegate void SceneDelegate(FrameEventArgs e);

        public SceneDelegate renderer;
        public SceneDelegate updater;
        public static Dictionary<int, string> myDictionary = new Dictionary<int, string>();
        public string ServerIp;
        public string masterIp;
        public int Port;

        private RenderTextOnScreen m_RenderText;

        public SceneManager()
        {
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);

            Width = 1024;
            Height = 512;
            width = Width;
            height = Height;
            m_RenderText = new RenderTextOnScreen(width, height);
            scene = new MainMenuScene(this, m_RenderText);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            updater(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            renderer(e);

            GL.Flush();
            SwapBuffers();
        }

        public void StartNewGame()
        {
            scene = new GameScene(this);
        }

        public void StartMenu()
        {
            scene = new MainMenuScene(this, m_RenderText);
        }

        public static int WindowWidth
        {
            get { return width; }
        }

        public static int WindowHeight
        {
            get { return height; }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
            width = Width;
            height = Height;
        }
    }
}