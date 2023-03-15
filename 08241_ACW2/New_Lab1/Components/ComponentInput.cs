namespace PongGame.Components
{
    internal class ComponentInput : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_INPUT;

        private readonly int m_Speed;

        public ComponentInput(int speed)
        {
            m_Speed = speed;
        }

        public int Speed => m_Speed;
    }
}