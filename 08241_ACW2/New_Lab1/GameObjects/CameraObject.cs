using OpenTK;

namespace PongGame.GameObjects
{
    internal class CameraObject
    {
        private Matrix4 projectionMatrix;
        private Matrix4 viewMatrix;
        public CameraObject(int width, int height)
        {
            projectionMatrix = Matrix4.CreateOrthographicOffCenter(0, width, 0, height, -1.0f, +1.0f);
            viewMatrix = Matrix4.Identity;
        }

        public Matrix4 Projection
        {
            get { return projectionMatrix; }
        }

        public Matrix4 Position
        {
            get { return viewMatrix; }
        }
    }
}