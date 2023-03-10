using OpenTK;

namespace PongGame.Components
{
    internal class ComponentTransform : IComponent
    {
        private Vector3 m_Position;

        public ComponentTransform(Vector3 pos)
        {
            m_Position = pos;
        }

        public Vector3 Position
        {
            get { return m_Position; }
            set { m_Position = value; }
        }

        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_TRANSFORM;
    }
}