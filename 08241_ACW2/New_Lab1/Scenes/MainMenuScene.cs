using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.Utility;
using System;
using System.Drawing;

namespace PongGame
{
    internal class MainMenuScene : Scene, IScene
    {
        private RenderText m_RenderText;

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

        }
        public void Update(FrameEventArgs e)
        {
            SelectMenu(new KeyboardKeyEventArgs());
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(0, sceneManager.Width, 0, sceneManager.Height, -1, 1);

            if (m_RenderText.BMP != null)
            {
                m_RenderText.RenderTextOnScreen("welcome to pong", 0f, 0f);
                m_RenderText.RenderTextOnScreen("1. single player game", 0f, 40f);
                m_RenderText.RenderTextOnScreen("2. multyplayer game", 0f, 80f);
                m_RenderText.RenderTextOnScreen("3. host networked game", 0f, 140f);
                m_RenderText.RenderTextOnScreen("4 connect to networked game", 0f, 180f);
                m_RenderText.RenderTextOnScreen("5. display high scores", 0, 220f);
            }
        }

        public void SelectMenu(KeyboardKeyEventArgs e)
        {
            KeyboardState keyState = Keyboard.GetState();
            if (keyState.IsKeyDown(Key.Number1))
            {
                sceneManager.StartNewGame();
            }
        }
    }
}