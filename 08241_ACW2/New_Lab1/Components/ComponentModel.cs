namespace PongGame.Components
{
    internal class ComponentModel : IComponent
    {
        private readonly int vao_id;
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_MODEL;

        public ComponentModel(int id)
        {
            vao_id = id;
        }

        public int VaoHandle
        {
            get { return vao_id; }
        }
    }
}