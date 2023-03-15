using PongGame.GameObjects;
using System.Collections.Generic;

namespace PongGame.Managers
{
    internal class EntityManager
    {
        private readonly List<GameObject> m_EntityList;
        private CameraObject m_CameraObject;

        public EntityManager()
        {
            m_EntityList = new List<GameObject>();
        }

        public EntityManager(CameraObject cameraObject)
        {
            m_EntityList = new List<GameObject>();
            m_CameraObject = cameraObject;
        }

        public CameraObject CurrentCam
        {
            get { return m_CameraObject; }
            set { m_CameraObject = value; }
        }

        public void AddEntity(GameObject entity)
        {
            //Entity result = FindEntity(entity.Name);
            // Debug.Assert(result != null, "Entity '" + entity.Name + "' already exists");
            m_EntityList.Add(entity);
        }

        public List<GameObject> Entities()
        {
            return m_EntityList;
        }

        public GameObject FindEntity(string name)
        {
            return m_EntityList.Find(delegate (GameObject e)
            {
                return e.Name == name;
            });
        }
    }
}