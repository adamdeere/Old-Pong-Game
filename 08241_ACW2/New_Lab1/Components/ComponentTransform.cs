using OpenTK;

namespace PongGame.Components
{
    internal class ComponentTransform : IComponent
    {
        private Vector2 m_Position;

        public ComponentTransform(float x, float y)
        {
            m_Position = new Vector2(x, y);
        }

        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_TRANSFORM;
    }
}