using PongGame.Components;
using System.Collections.Generic;
using System.Diagnostics;

namespace PongGame.GameObjects
{
    internal class GameObject
    {
        private string m_Name;
        private readonly List<IComponent> componentList = new List<IComponent>();
        private ComponentTypes mask;

        public GameObject(string name)
        {
            m_Name = name;
        }

        public IComponent FindComponent(ComponentTypes type)
        {
            IComponent transformComponent = componentList.Find(delegate (IComponent component)
            {
                return component.ComponentType == type;
            });

            return transformComponent;
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