using UnityEngine;

namespace PersonalLibrary.Extensions
{
    public static class VectorExtensions
    {
        #region Vector3
        public static Vector3 xyz (this Vector3 vector3, float x, float y, float z)
        {
            vector3.x = x;
            vector3.y = y;
            vector3.z = z;
            return vector3;
        }

        public static Vector3 xy(this Vector3 vector3, float x, float y)
        {
            vector3.x = x;
            vector3.y = y;
            return vector3;
        }

        public static Vector3 xz(this Vector3 vector3, float x, float z)
        {
            vector3.x = x;
            vector3.z = z;
            return vector3;
        }

        public static Vector3 yz(this Vector3 vector3, float y, float z)
        {
            vector3.y = y;
            vector3.z = z;
            return vector3;
        }
        #endregion

        #region Vector2
        public static Vector2 xy(this Vector2 vector2, float x, float y)
        {
            vector2.x = x;
            vector2.y = y;
            return vector2;
        }

        public static Vector2 x(this Vector2 vector2, float x)
        {
            vector2.x = x;
            return vector2;
        }

        public static Vector2 y(this Vector2 vector2, float y)
        {
            vector2.y = y;
            return vector2;
        }

        public static Vector2 Swap(this Vector2 vector2)
        {
            var temp = vector2.x;
            vector2.x = vector2.y;
            vector2.y = temp;
            return vector2;
        }
        #endregion
    }
}