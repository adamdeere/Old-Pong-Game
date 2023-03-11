namespace PongGame.Components
{
    internal class ComponentBallCollsion : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_BALL_COLLSION;

        public int Radius
        {
            get { return 10; }
        }
    }
}