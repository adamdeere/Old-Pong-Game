using OpenTK;
using OpenTK.Graphics.OpenGL;
using PongGame.Managers;
using System;

namespace PongGame
{
    internal class Game : GameWindow
    {
        private static int width = 1024;
        private static int height = 512;

        public Game()
        {
            Width = width;
            Height = height;
            SceneManager.ChangeScene(new MainMenuScene());
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            SceneManager.LoadScene(e);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
            SceneManager.UpdateScene(e);
        }

        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            SceneManager.RenderScene(e);
            GL.Flush();
            SwapBuffers();
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