using OpenTK;
using PongGame.Managers;
using PongGame.Systems.GameSystems;
using PongGame.Systems;
using PongGame.Utility;
using System;
using PongGame.GameObjects;
using System.Drawing;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace PongGame.Scenes
{
    internal class LocalMultiPlayerScene : IScene
    {
        private double gameTime = 30;

        private readonly EntityManager entityManager;
        private readonly SystemManager systemManager;
        private readonly RenderText m_RenderText;

        private readonly Vector3[] vertdata = new Vector3[] {
                new Vector3(-10f, +30f, 0f),
                new Vector3(-10f, -30f, 0f),
                new Vector3(+10f, -30f, 0f),
                new Vector3(+10f, +30f, 0f) };

        private readonly Vector3[] coldata = new Vector3[] {
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f) };

        private readonly Vector3[] ballVertData = new Vector3[] {
                new Vector3(-10f, +10f, 0f),
                new Vector3(-10f, -10f, 0f),
                new Vector3(+10f, -10f, 0f),
                new Vector3(+10f, +10f, 0f) };

        private readonly CameraObject m_CamObject;
        private int m_Width, m_Height;

        public LocalMultiPlayerScene() 
        {
            m_Width = Game.WindowWidth;
            m_Height = Game.WindowHeight;
            m_CamObject = new CameraObject(m_Width, m_Height);
            GL.ClearColor(Color.Black);
            entityManager = new EntityManager(m_CamObject);
            systemManager = new SystemManager();
            m_RenderText = new RenderText(Game.WindowWidth, 100);
            CreateEntities();
            CreateSystems();
        }  
        public void Load(EventArgs e)
        {
            throw new NotImplementedException();
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, m_Width, m_Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            systemManager.ActionRenderSystems(entityManager);
        }

        public void Update(FrameEventArgs e)
        {
            systemManager.ActionPlayerInputSystems(entityManager, Keyboard.GetState(), (float)e.Time);
            systemManager.ActionUpdateSystems(entityManager, (float)e.Time);
        }

        private void CreateEntities()
        {
            int paddle = LoadVerts.LoadModelVerts(vertdata, coldata);
            int ball = LoadVerts.LoadModelVerts(ballVertData, coldata);

            entityManager.AddEntity(new PlayerPaddle("PaddleOne", paddle));
            entityManager.AddEntity(new PlayerTwoPaddle("PaddleTwo", paddle));
            entityManager.AddEntity(new Ball("Ball", ball));
            entityManager.AddEntity(new GameManagerObject("GameManager", gameTime));
        }

        private void CreateSystems()
        {
            // add render systems
            systemManager.AddRenderSystem(new SystemRender());
            systemManager.AddRenderSystem(new SystemRenderGameText(m_RenderText));
            // add update systems
            systemManager.AddUpdateSystem(new SystemPhysics());
            systemManager.AddUpdateSystem(new SystemCollsion());
            systemManager.AddUpdateSystem(new SystemGoalDetection());
            systemManager.AddUpdateSystem(new SystemGameManager(m_RenderText));
            // add input systems
            systemManager.AddInputSystem(new SystemPlayerInput());
        }
    }
}
