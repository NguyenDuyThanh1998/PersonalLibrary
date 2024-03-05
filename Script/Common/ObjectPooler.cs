using System.Collections.Generic;
using UnityEngine;

using Defenders.Datagram;

namespace PersonalLibrary.Common
{
    public class ObjectPooler : Singleton<ObjectPooler>
    {
        Transform m_Transform;

        [System.Serializable]
        public class Pool
        {
            public EPoolingObject type;
            public GameObject prefab;
            public int size;
        }

        [SerializeField] List<Pool> Pools;
        [SerializeField] Dictionary<EPoolingObject, Queue<GameObject>> PoolingDictionary;

        private void Awake()
        {
            m_Transform = transform;

            if (m_Transform.childCount > 0)
            {
                m_Transform.ClearAllChild();
            }
        }

        private void Start()
        {
            PoolingDictionary = new Dictionary<EPoolingObject, Queue<GameObject>>();
            foreach (Pool pool in Pools)
            {
                GameObject poolHolder = new();
                poolHolder.name = pool.type.ToString();
                poolHolder.transform.parent = m_Transform;

                Queue<GameObject> queue = new Queue<GameObject>();
                for (int i = 0; i < pool.size; i++)
                {
                    GameObject objectToQueue = Instantiate(pool.prefab, poolHolder.transform);
                    objectToQueue.SetActive(false);
                    queue.Enqueue(objectToQueue);
                }
                PoolingDictionary.Add(pool.type, queue);
            }
        }

        public GameObject SpawnFromPool(EPoolingObject _type, Vector2 _position)
        {
            // Setup object to spawn.
            GameObject objectToSpawn = PoolingDictionary[_type].Dequeue();
            objectToSpawn.transform.position = _position;
            objectToSpawn.SetActive(true);

            // Re-add the object into queue for later use.
            PoolingDictionary[_type].Enqueue(objectToSpawn);
            return objectToSpawn;
        }
    }
}
