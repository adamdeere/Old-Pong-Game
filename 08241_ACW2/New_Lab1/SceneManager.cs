using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace PongGame
{
    internal class SceneManager : GameWindow
    {
        private Scene scene;
        private static int width = 1024;
        private static int height = 512;

        public delegate void SceneDelegate(FrameEventArgs e);

        public delegate void SceneLoadDelegate(EventArgs e);

        public SceneDelegate renderer;
        public SceneDelegate updater;
        public SceneLoadDelegate loader;

        public SceneManager()
        {
            Width = width;
            Height = height;
            scene = new MainMenuScene(this);
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            loader(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
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
            scene = new MainMenuScene(this);
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