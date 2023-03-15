using OpenTK;
using PongGame.Scenes;
using System;
using System.Collections.Generic;

namespace PongGame.Managers
{
    internal static class SceneManagerRefactor
    {
        private static List<ISceneRefactor> m_SceneList = new List<ISceneRefactor>();

        public static void ChangeScene(ISceneRefactor scene)
        {
            if (m_SceneList.Count > 0)
                m_SceneList.Clear();
           
            m_SceneList.Add(scene);
        }
        public static void LoadScene(EventArgs e)
        {
            foreach (var item in m_SceneList)
            {
                item.Load(e);
            }
        }
        public static void UpdateScene(FrameEventArgs e)
        {
            for (int i = 0; i < m_SceneList.Count; i++)
            {
                m_SceneList[i].Update(e);
            }
        }

        public static void RenderScene(FrameEventArgs e)
        {
            for (int i = 0; i < m_SceneList.Count; i++)
            {
                m_SceneList[i].Render(e);
            }
        }
    }
}
