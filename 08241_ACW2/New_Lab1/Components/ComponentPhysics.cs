using OpenTK;
using System;

namespace PongGame.Components
{
    internal class ComponentPhysics : IComponent
    {
        private Vector2 m_Velocity;

        private readonly Random rand = new Random();
        public ComponentTypes ComponentType => ComponentTypes.COMPONENT_PHYSICS;

        public ComponentPhysics()
        {
            m_Velocity = RandomVelocity();
        }

        public Vector2 RandomVelocity()
        {
            Vector2 vel = (new Vector2(((float)rand.NextDouble() * 2.0f) - 1.0f, ((float)rand.NextDouble() * 2.0f) - 1.0f));
            vel.Normalize();
            vel *= 100.0f;
            return vel;
        }

        public Vector2 Velocity
        {
            get { return m_Velocity; }
            set { m_Velocity = value; }
        }
    }
}