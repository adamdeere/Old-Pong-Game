using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;

namespace PongGame.Utility
{
    internal static class LoadVerts
    {
        public static int LoadModelVerts(Vector3[] vertdata, Vector3[] coldata)
        {
            // Store geometry in vertex buffer
            GL.GenVertexArrays(1, out int vao_Handle);
            GL.BindVertexArray(vao_Handle);

            GL.GenBuffers(1, out int vbo_position);
            GL.GenBuffers(1, out int vbo_color);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_position);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(vertdata.Length * Vector3.SizeInBytes), vertdata, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(0);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 0, 0);

            GL.BindBuffer(BufferTarget.ArrayBuffer, vbo_color);
            GL.BufferData(BufferTarget.ArrayBuffer, (IntPtr)(coldata.Length * Vector3.SizeInBytes), coldata, BufferUsageHint.StaticDraw);
            GL.EnableVertexAttribArray(1);
            GL.VertexAttribPointer(1, 3, VertexAttribPointerType.Float, true, 0, 0);

            GL.BindVertexArray(0);
            return vao_Handle;
        }
    }
}