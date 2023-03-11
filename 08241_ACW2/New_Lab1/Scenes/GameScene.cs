﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using PongGame.Components;
using PongGame.GameObjects;
using PongGame.Managers;
using PongGame.Systems;
using PongGame.Utility;
using System.Drawing;

namespace PongGame
{
    internal class GameScene : Scene, IScene
    {
        private Matrix4 projectionMatrix;

        private PlayerPaddle paddlePlayer;
        private AIPaddle paddleAI;
        private Ball ball;
        private int scorePlayer = 9;
        private int scoreAI = 0;
        private double gameTime = 30;

        private EntityManager entityManager;
        private readonly SystemManager systemManager;

        private Vector3[] vertdata = new Vector3[] {
                new Vector3(-10f, +30f, 0f),
                new Vector3(-10f, -30f, 0f),
                new Vector3(+10f, -30f, 0f),
                new Vector3(+10f, +30f, 0f) };

        private Vector3[] coldata = new Vector3[] {
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f),
                new Vector3(1f, 1f, 1f) };

        private Vector3[] ballVertData = new Vector3[] {
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
            CreateEntities();
            CreateSystems();
        }

        private void CreateEntities()
        {
            int paddle = LoadVerts.LoadModelVerts(vertdata, coldata);
            int ball = LoadVerts.LoadModelVerts(ballVertData, coldata);

            Entity newEntity;
            newEntity = new Entity("Paddle");
            newEntity.AddComponent(new ComponentModel(paddle));
            newEntity.AddComponent(new ComponentTransform(40, (int)(SceneManager.WindowHeight * 0.5)));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("AI Paddle");
            newEntity.AddComponent(new ComponentModel(paddle));
            newEntity.AddComponent(new ComponentTransform(SceneManager.WindowWidth - 40, (int)(SceneManager.WindowHeight * 0.5)));
            entityManager.AddEntity(newEntity);

            newEntity = new Entity("Ball");
            newEntity.AddComponent(new ComponentModel(ball));
            newEntity.AddComponent(new ComponentTransform((int)(SceneManager.WindowWidth * 0.5), (int)(SceneManager.WindowHeight * 0.5)));
            entityManager.AddEntity(newEntity);
        }

        private void CreateSystems()
        {
            IRenderSystems newSystem;

            newSystem = new SystemRender();
            systemManager.AddRenderSystem(newSystem);

            IUpdateSystems newUpdateSystem;

            newUpdateSystem = new SystemPhysics();
            systemManager.AddUpdateSystem(newUpdateSystem);
        }

        private void ResetGame()
        {
            paddlePlayer = new PlayerPaddle(40, (int)(SceneManager.WindowHeight * 0.5));
            paddlePlayer.Init();
            paddleAI = new AIPaddle(SceneManager.WindowWidth - 40, (int)(SceneManager.WindowHeight * 0.5));
            paddleAI.Init();
            ball = new Ball((int)(SceneManager.WindowWidth * 0.5), (int)(SceneManager.WindowHeight * 0.5));
            ball.Init();
        }

        public void Keyboard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    paddlePlayer.Move(20);
                    break;

                case Key.Down:
                    paddlePlayer.Move(-20);
                    break;
            }
        }

        public void Update(FrameEventArgs e)
        {
            /*
            // Set the title of the window
            if (gameTime > 0)
            {
                sceneManager.Title = "Pong - Player Score: " + scorePlayer + " - AI Score: " + scoreAI + " time remaining " + Math.Truncate(gameTime);

                paddleAI.Move(ball.Position);

                ball.Update((float)e.Time);
                paddleAI.Update((float)e.Time);

                CollisionDetection();
                if (GoalDetection())
                {
                    ResetGame();
                }
                gameTime -= (1.0 * e.Time);
            }
            else
            {
                sceneManager.StartMenu();
            }
            */
        }

        private bool GoalDetection()
        {
            if (ball.Position.X < 0)
            {
                scoreAI++;
                return true;
            }
            else if (ball.Position.X > SceneManager.WindowWidth)
            {
                scorePlayer++;
                return true;
            }

            return false;
        }

        private void CollisionDetection()
        {
            // AI
            if ((paddleAI.Position.X - ball.Position.X) < ball.Radius &&
               ball.Position.Y > (paddleAI.Position.Y - 35.0f) && ball.Position.Y < (paddleAI.Position.Y + 35.0f))
            {
                ball.Position = new Vector2(paddleAI.Position.X - ball.Radius, ball.Position.Y);
                ball.Velocity = new Vector2(ball.Velocity.X * -1.0f, ball.Velocity.Y) * 2.0f;
            }
            // Player
            if ((ball.Position.X - paddlePlayer.Position.X) < ball.Radius &&
               ball.Position.Y > (paddlePlayer.Position.Y - 35.0f) && ball.Position.Y < (paddlePlayer.Position.Y + 35.0f))
            {
                ball.Position = new Vector2(paddlePlayer.Position.X + ball.Radius, ball.Position.Y);
                ball.Velocity = new Vector2(ball.Velocity.X * -1.0f, ball.Velocity.Y) * 2.0f;
            }
        }

        public void Render(FrameEventArgs e)
        {
            GL.Viewport(0, 0, sceneManager.Width, sceneManager.Height);
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
            systemManager.ActionRenderSystems(entityManager);
            // projectionMatrix = m_CamObject.Projection;

            //ball.Render(projectionMatrix);
            // paddlePlayer.Render(projectionMatrix);
            // paddleAI.Render(projectionMatrix);
        }
    }
}