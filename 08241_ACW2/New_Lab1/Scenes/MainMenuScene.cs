﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PongGame
{
    internal class MainMenuScene : Scene, IScene
    {
        private Bitmap textBMP;
        private int textTexture;
        private Graphics textGFX;
        public static string serverIp;
        public static string masterIp;
        public static int portNo;

        private Client client;
        private MasterServer master;

        public MainMenuScene(SceneManager sceneManager)
            : base(sceneManager)
        {
            // Set the title of the window
            sceneManager.Title = "Pong - Main Menu";
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;

            // Create Bitmap and OpenGL texture for rendering text
            textBMP = new Bitmap(sceneManager.Width, sceneManager.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // match window size
            textGFX = Graphics.FromImage(textBMP);
            textGFX.Clear(Color.CornflowerBlue);
            textTexture = GL.GenTexture();
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textBMP.Width, textBMP.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Texture2D);
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

            if (textBMP != null)
            {
                RenderText("welcome to pong", 0f, 0f);
                RenderText("1. single player game", 0f, 40f);
                RenderText("2. multyplayer game", 0f, 80f);
                RenderText("3. host networked game", 0f, 140f);
                RenderText("4 connect to networked game", 0f, 180f);
                RenderText("5. display high scores", 0, 220f);
            }
        }

        private void RenderText(string text, float x, float y)
        {
            textGFX.DrawString(text, new Font("Arial", 20), Brushes.White, x, y);

            // Enable the texture
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textTexture);

            BitmapData data = textBMP.LockBits(new Rectangle(0, 0, textBMP.Width, textBMP.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, (int)textBMP.Width, (int)textBMP.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            textBMP.UnlockBits(data);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0f, 0f);
            GL.TexCoord2(1f, 1f); GL.Vertex2(sceneManager.Width, 0f);
            GL.TexCoord2(1f, 0f); GL.Vertex2(sceneManager.Width, sceneManager.Height);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0f, sceneManager.Height);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Texture2D);
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