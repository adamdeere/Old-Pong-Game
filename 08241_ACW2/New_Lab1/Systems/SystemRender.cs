using OpenTK;
using OpenTK.Graphics.OpenGL;
using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;
using System;
using System.Collections.Generic;
using System.IO;

namespace PongGame.Systems
{
    internal class SystemRender : IRenderSystems
    {
        protected int pgmID;

        protected int vsID;
        protected int fsID;
        protected int uniform_mview;

        public string Name => "SystemRenderColour";

        private const ComponentTypes MASK =
              ComponentTypes.COMPONENT_TRANSFORM
            | ComponentTypes.COMPONENT_MODEL;

        public SystemRender()
        {
            pgmID = GL.CreateProgram();
            LoadShader("Shaders/vs.glsl", ShaderType.VertexShader, pgmID, out vsID);
            LoadShader("Shaders/fs.glsl", ShaderType.FragmentShader, pgmID, out fsID);
            GL.LinkProgram(pgmID);
            Console.WriteLine(GL.GetProgramInfoLog(pgmID));

            uniform_mview = GL.GetUniformLocation(pgmID, "WorldViewProj");

            if (uniform_mview == -1)
            {
                Console.WriteLine("Error binding attributes");
            }
        }

        public void OnAction(EntityManager entityManager)
        {
            GL.UseProgram(pgmID);
            CameraObject camera = entityManager.CurrentCam;
            foreach (var entity in entityManager.Entities())
            {
                if ((entity.Mask & MASK) == MASK)
                {
                    List<IComponent> components = entity.Components;

                    IComponent modelComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_MODEL;
                    });

                    int vao = ((ComponentModel)modelComponent).VaoHandle;

                    IComponent transformComponent = components.Find(delegate (IComponent component)
                    {
                        return component.ComponentType == ComponentTypes.COMPONENT_TRANSFORM;
                    });
                    Vector2 position = ((ComponentTransform)transformComponent).Position;
                    Draw(vao, position, camera);
                }
            }
            GL.UseProgram(0);
        }

        private void Draw(int vao_Handle, Vector2 pos, CameraObject cam)
        {
            GL.BindVertexArray(vao_Handle);

            Matrix4 worldMatrix = Matrix4.CreateTranslation(pos.X, pos.Y, 0);
            Matrix4 worldViewProjection = worldMatrix * cam.View * cam.Projection;
            GL.UniformMatrix4(uniform_mview, false, ref worldViewProjection);

            GL.DrawArrays(PrimitiveType.TriangleFan, 0, 4);

            GL.BindVertexArray(0);
        }

        private void LoadShader(string filename, ShaderType type, int program, out int address)
        {
            address = GL.CreateShader(type);
            using (StreamReader sr = new StreamReader(filename))
            {
                GL.ShaderSource(address, sr.ReadToEnd());
            }
            GL.CompileShader(address);
            GL.AttachShader(program, address);
            Console.WriteLine(GL.GetShaderInfoLog(address));
        }
    }
}