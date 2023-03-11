using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.Utility;

namespace PongGame
{
    internal class MainMenuScene : Scene, IScene
    {
        private readonly RenderTextOnScreen m_RenderText;

        public MainMenuScene(SceneManager sceneManager)
            : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Pong - Main Menu";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
            m_RenderText = new RenderTextOnScreen(sceneManager.Width, sceneManager.Height);
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
                m_RenderText.RenderText("welcome to pong", 0f, 0f);
                m_RenderText.RenderText("1. single player game", 0f, 40f);
                m_RenderText.RenderText("2. multyplayer game", 0f, 80f);
                m_RenderText.RenderText("3. host networked game", 0f, 140f);
                m_RenderText.RenderText("4 connect to networked game", 0f, 180f);
                m_RenderText.RenderText("5. display high scores", 0, 220f);
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