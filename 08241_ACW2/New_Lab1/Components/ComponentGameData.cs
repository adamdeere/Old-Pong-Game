namespace PongGame.Components
{
    internal class ComponentGameData : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_GAME_MANAGER;
        private double m_GameTime;
        public ComponentGameData(double gameTime) 
        {
            m_GameTime= gameTime;
        }

        public double GameTime
        {
            get { return m_GameTime; }
            set { m_GameTime = value; }
        }
    }
}
