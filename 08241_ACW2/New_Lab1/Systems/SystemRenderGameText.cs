﻿using PongGame.Components;
using PongGame.Managers;
using PongGame.Utility;
using System.Collections.Generic;

namespace PongGame.Systems
{
    internal class SystemRenderGameText : IRenderSystems
    {
        public string Name => "SystemRenderGameText";

        private const ComponentTypes MASK =
             ComponentTypes.COMPONENT_SCORE_DATA;

        private readonly RenderText m_RenderText;

        public SystemRenderGameText(RenderText renderText)
        {
            m_RenderText = renderText;
        }

        public void OnAction(EntityManager entityManager)
        {
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent scoreDataComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_SCORE_DATA;
                    });
                    ComponentScoreData score = scoreDataComponent as ComponentScoreData;

                    if (m_RenderText.BMP != null)
                    {
                        m_RenderText.RenderTextOnScreen(score.Name + " Score " + score.Score, score.Offset, 0f);
                    }
                }
            }
        }
    }
}