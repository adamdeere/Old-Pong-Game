using PongGame.Components;
using PongGame.Managers;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemRender : IRenderSystems
    {
        public string Name => "SystemRenderColour";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_TRANSFORM
            | ComponentTypes.COMPONENT_MODEL;

        public void OnAction(EntityManager entityList)
        {
            foreach (var entity in entityList.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;
                    /*
                    IComponent? modelComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_MODEL;
                    });
                    Model geometry = ((ComponentModel)modelComponent).Model;
                    */
                    Draw();
                }
            }
        }

        private void Draw()
        {
        }
    }
}