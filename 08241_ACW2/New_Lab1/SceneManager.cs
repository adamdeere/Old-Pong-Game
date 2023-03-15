using OpenTK;
using OpenTK.Graphics.OpenGL;
using PongGame.Managers;
using System;
using System.Runtime.CompilerServices;

namespace PongGame
{
    internal class SceneManager : GameWindow
    { 
        private static int width = 1024;
        private static int height = 512;

        public SceneManager()
        {
            Width = width;
            Height = height;
            SceneManagerRefactor.ChangeScene(new MainMenuScene());
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            GL.Enable(EnableCap.DepthTest);
            SceneManagerRefactor.LoadScene(e);
        }
        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);
           SceneManagerRefactor.UpdateScene(e);
        }
        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

           SceneManagerRefactor.RenderScene(e);
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