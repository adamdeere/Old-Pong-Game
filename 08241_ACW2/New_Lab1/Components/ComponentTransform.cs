using OpenTK;

namespace PongGame.Components
{
    internal class ComponentTransform : IComponent
    {
        private Vector2 m_Position;
        private Vector2 m_OldPosition;

        public ComponentTransform(float x, float y)
        {
            m_Position = new Vector2(x, y);
            m_OldPosition = m_Position;
        }

        public Vector2 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public Vector2 OldPosition
        {
            get { return m_OldPosition; }
            set { m_OldPosition = value; }
        }
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_TRANSFORM;
    }
}