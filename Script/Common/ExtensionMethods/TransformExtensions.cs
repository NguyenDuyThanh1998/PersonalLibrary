using UnityEngine;

namespace PersonalLibrary.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Destroy all child gameobjects.
        /// </summary>
        public static Transform DestroyAllChildren(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
            return transform;
        }

        /// <summary>
        /// Destroy all child gameobjects in edit mode.
        /// Destroying an object in edit mode destroys it permanently.
        /// </summary>
        public static Transform DestroyImmedeateAllChildren(this Transform transform)
        {
            while (transform.childCount > 0)
            {
                Object.DestroyImmediate(transform.GetChild(0).gameObject);
            }
            return transform;
        }

        /// <summary>
        /// Flip GameObject on it's X axis by multiplying it's localscale.x with "-1".
        /// </summary>
        public static Transform FlipX(this Transform transform)
        {
            Vector3 scale = transform.localScale;
            transform.localScale = scale.xy(scale.x * -1, scale.y);
            //transform.localScale = new Vector3(scale.x * -1, scale.y);
            return transform;
        }

        /// <summary>
        /// Flip GameObject on it's Y axis by multiplying it's localscale.y with "-1".
        /// </summary>
        public static Transform FlipY(this Transform transform)
        {
            Vector3 scale = transform.localScale;
            transform.localScale = scale.xy(scale.x, scale.y * -1);
            //transform.localScale = new Vector3(scale.x, scale.y * -1);
            return transform;
        }
    }
}