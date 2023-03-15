using OpenTK;
using System;

namespace PongGame.Scenes
{
    internal interface ISceneRefactor
    {
        void Load(EventArgs e);
        void Render(FrameEventArgs e);
        void Update(FrameEventArgs e);
    }
}
