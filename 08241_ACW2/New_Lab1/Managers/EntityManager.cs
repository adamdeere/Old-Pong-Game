using PongGame.GameObjects;
using System.Collections.Generic;

namespace PongGame.Managers
{
    internal class EntityManager
    {
        private readonly List<Entity> m_EntityList;
        private CameraObject m_CameraObject;

        public EntityManager(CameraObject cameraObject)
        {
            m_EntityList = new List<Entity>();
            m_CameraObject = cameraObject;
        }

        public CameraObject CurrentCam
        {
            get { return m_CameraObject; }
            set { m_CameraObject = value; }
        }

        public void AddEntity(Entity entity)
        {
            //Entity result = FindEntity(entity.Name);
            // Debug.Assert(result != null, "Entity '" + entity.Name + "' already exists");
            m_EntityList.Add(entity);
        }

        public List<Entity> Entities()
        {
            return m_EntityList;
        }

        public Entity FindEntity(string name)
        {
            return m_EntityList.Find(delegate (Entity e)
            {
                return e.Name == name;
            });
        }
    }
}