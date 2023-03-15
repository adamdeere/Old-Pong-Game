namespace PongGame.Components
{
    internal class ComponentBallCollsion : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_BALL_COLLSION;
        private readonly int m_Radius;

        public ComponentBallCollsion(int radius)
        {
            m_Radius = radius;
        }

        public int Radius
        {
            get { return m_Radius; }
        }
    }
}