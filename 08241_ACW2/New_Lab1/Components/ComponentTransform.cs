namespace PongGame.Components
{
    internal class ComponentTransform : IComponent
    {
        private float x_Pos, y_Pos;

        public ComponentTransform(float x, float y)
        {
            x_Pos = x;
            y_Pos = y;
        }

        public float XPosition
        {
            get { return x_Pos; }
            set { x_Pos = value; }
        }

        public float YPosition
        {
            get { return y_Pos; }
            set { y_Pos = value; }
        }

        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_TRANSFORM;
    }
}