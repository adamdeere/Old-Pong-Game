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
        COMPONENT_INPUT = 1 << 5,
        COMPONENT_BALL_COLLSION = 1 << 6,
        COMPONENT_SCORE_DATA = 1 << 7,
        COMPONENT_GAME_MANAGER = 1 << 8,
        COMPONENT_SECOND_INPUT = 1 << 9,
    }

    internal interface IComponent
    {
        ComponentTypes ComponentType
        {
            get;
        }
    }
}