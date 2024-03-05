using UnityEngine;

namespace PersonalLibrary.Common
{
    public static class RigidBody2DExtensions
    {
        public static bool Freeze(this Rigidbody2D rigidbody2D)
        {
            if (!rigidbody2D)
            {
                Debug.LogError("rigidbody2D is null");
                return false;
            }
            else
            {
                rigidbody2D.velocity = Vector2.zero;
                rigidbody2D.angularVelocity = 0;
                rigidbody2D.isKinematic = true;
                return true;
            }
        }
    }
}