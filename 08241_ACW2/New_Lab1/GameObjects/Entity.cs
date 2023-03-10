using PongGame.Components;
using System.Collections.Generic;
using System.Diagnostics;

namespace PongGame.GameObjects
{
    internal class Entity
    {
        private string m_Name;
        private List<IComponent> componentList = new List<IComponent>();
        private ComponentTypes mask;

        public Entity(string name)
        {
            m_Name = name;
        }

        public void AddComponent(IComponent component)
        {
            Debug.Assert(component != null, "Component cannot be null");

            componentList.Add(component);
            mask |= component.ComponentType;
        }

        public string Name
        {
            get { return m_Name; }
            set { m_Name = value; }
        }

        public ComponentTypes Mask
        {
            get { return mask; }
        }

        public List<IComponent> Components
        {
            get { return componentList; }
        }
    }
}