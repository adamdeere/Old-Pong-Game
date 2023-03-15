namespace PongGame.Components
{
    internal class ComponentSecondInput : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_SECOND_INPUT;

        private readonly int m_Speed;

        public ComponentSecondInput(int speed)
        {
            m_Speed = speed;
        }

        public int Speed => m_Speed;
    }
}