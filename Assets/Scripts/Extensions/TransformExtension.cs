using UnityEngine;

namespace Extensions
{
    public static class TransformExtension
    {
        public static Transform Clear(this Transform transform)
        {
            foreach (Transform child in transform)
            {
                Object.Destroy(child.gameObject);
            }
            return transform;
        }
    }
}
