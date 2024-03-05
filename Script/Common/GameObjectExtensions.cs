using UnityEngine;

namespace PersonalLibrary.Common
{
    public static class GameObjectExtensions
    {
        /// <summary>
        /// GetComponent in GameObject or additionally, AddComponent if it doesn't exist yet.
        /// </summary>
        public static T Get<T>(this GameObject gameObject) where T : Component
        {
            return gameObject.GetComponent<T>() ?? gameObject.AddComponent<T>();
        }

        /// <summary>
        /// GetComponent in Parent GameObject or additionally, AddComponent if it doesn't exist yet.
        /// </summary>
        public static T GetInParent<T>(this GameObject gameObject) where T : Component
        {
            GameObject parent = gameObject.transform.parent.gameObject;
            return parent.GetComponent<T>() ?? parent.AddComponent<T>();
        }

        /// <summary>
        /// Get parent GameObject
        /// <param name="parentLevel">
        /// Parent GameObject level in hierarchy.
        /// </param>
        /// </summary>
        public static GameObject ParentLevel(this GameObject gameObject, int parentLevel)
        {
            Transform transform = gameObject.transform;
            for (int i = 0; i < parentLevel; i++)
            {
                transform = transform.parent;
            }
            return transform.gameObject;
        }
    }
}