﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.GameObjects;
using PongGame.Managers;
using PongGame.Systems;
using PongGame.Systems.GameSystems;
using PongGame.Utility;
using System.Drawing;

namespace PongGame
{
    internal class GameScene : Scene, IScene
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

        public GameScene(SceneManager sceneManager)
            : base(sceneManager)
        {
            // Set the Render and Update delegates to the Update and Render methods of this class
            sceneManager.renderer = Render;
            sceneManager.updater = Update;
            // Set Keyboard events to go to a method in this class
            sceneManager.Keyboard.KeyDown += Keyboard_KeyDown;

            // ResetGame();
            m_CamObject = new CameraObject(sceneManager.Width, sceneManager.Height);
            GL.ClearColor(Color.Black);
            entityManager = new EntityManager(m_CamObject);
            systemManager = new SystemManager();
            m_RenderText = new RenderText(SceneManager.WindowWidth, 100);
            CreateEntities();
            CreateSystems();
        }

        private void CreateEntities()
        {
            int paddle = LoadVerts.LoadModelVerts(vertdata, coldata);
            int ball = LoadVerts.LoadModelVerts(ballVertData, coldata);

            entityManager.AddEntity(new PlayerPaddle("PaddleOne", paddle));
            entityManager.AddEntity(new AIPaddle("PaddleTwo", paddle));
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
            systemManager.AddUpdateSystem(new SystemGameManager(sceneManager, m_RenderText));
            systemManager.AddUpdateSystem(new SystemAI());
            // add input systems
            systemManager.AddInputSystem(new SystemPlayerInput());
        }

        public void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            /*
            switch (e.Key)
            {
                case Key.Up:
                    paddlePlayer.Move(20);
                    break;

                case Key.Down:
                    paddlePlayer.Move(-20);
                    break;
            }
            */
        }

        public void Update(FrameEventArgs e)
        {
            systemManager.ActionPlayerInputSystems(entityManager, Keyboard.GetState(), (float)e.Time);
            systemManager.ActionUpdateSystems(entityManager, (float)e.Time);
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            systemManager.ActionRenderSystems(entityManager);
        }
    }
}