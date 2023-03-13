using OpenTK.Graphics.OpenGL;
using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace PongGame.Utility
{
    internal class RenderText
    {
        private readonly Bitmap textBMP;
        private readonly int textTexture;
        private readonly Graphics textGFX;

        private readonly int width, height;

        public RenderText(int width, int height)
        {
            this.width = width;
            this.height = height;
            // Create Bitmap and OpenGL texture for rendering text
            textBMP = new Bitmap(width, height, System.Drawing.Imaging.PixelFormat.Format32bppArgb); // match window size
            textGFX = Graphics.FromImage(textBMP);
            textGFX.Clear(Color.Black);
            textTexture = GL.GenTexture();
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textTexture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)All.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)All.Linear);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textBMP.Width, textBMP.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, IntPtr.Zero);
            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Texture2D);
        }

        public Bitmap BMP
        {
            get { return textBMP; }
        }

        public void RenderTextOnScreen(string text, float x, float y)
        {
            textGFX.ResetClip();
            textGFX.DrawString(text, new Font("Arial", 20), Brushes.White, x, y);

            // Enable the texture
            GL.Enable(EnableCap.Texture2D);
            GL.BindTexture(TextureTarget.Texture2D, textTexture);

            BitmapData data = textBMP.LockBits(new Rectangle(0, 0, textBMP.Width, textBMP.Height), ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, textBMP.Width, (int)textBMP.Height, 0, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            textBMP.UnlockBits(data);

            GL.Begin(PrimitiveType.Quads);
            GL.TexCoord2(0f, 1f); GL.Vertex2(0f, 0f);
            GL.TexCoord2(1f, 1f); GL.Vertex2(width, 0f);
            GL.TexCoord2(1f, 0f); GL.Vertex2(width, height);
            GL.TexCoord2(0f, 0f); GL.Vertex2(0f, height);
            GL.End();

            GL.BindTexture(TextureTarget.Texture2D, 0);
            GL.Disable(EnableCap.Texture2D);
        }
    }
}