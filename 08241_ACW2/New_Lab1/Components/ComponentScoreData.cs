namespace PongGame.Components
{
    internal class ComponentScoreData : IComponent
    {
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_SCORE_DATA;
        private string _name;
        private float _offset;

        public ComponentScoreData(string name, float offset)
        {
            _name = name;
            _offset = offset;
        }

        public float Offset => _offset;
        public string Name => _name;
        public int Score { get; set; }
    }
}