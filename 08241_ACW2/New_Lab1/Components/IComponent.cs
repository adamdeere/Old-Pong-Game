namespace PongGame.Components
{
    internal enum ComponentTypes
    {
        COMPONENT_NONE = 0,
        COMPONENT_TRANSFORM = 1 << 0,
        COMPONENT_MODEL = 1 << 1,
        COMPONENT_PHYSICS = 1 << 2,
        COMPONENT_COLISION = 1 << 3,
        COMPONENT_AI = 1 << 4,
    }

    internal interface IComponent
    {
        ComponentTypes ComponentType
        {
            get;
        }
    }
}