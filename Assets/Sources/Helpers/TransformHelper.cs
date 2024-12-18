using UnityEngine;

namespace SpaceRoguelike.Helpers
{

    /// <summary>
    /// Helper class that contains misc helpful functions with <see cref="Transform"/>
    /// </summary>
    public static class TransformHelper
    {
        /// <summary>
        /// Get the nearest transform to <paramref name="self"/>
        /// </summary>
        /// <param name="self"></param>
        /// <param name="transforms"></param>
        /// <returns></returns>
        public static Transform GetNearest(Transform self, params Transform[] transforms)
        {
            Transform nearest = null;
            float minimalDistance = float.PositiveInfinity;
            foreach(Transform transform in transforms)
            {
                if(nearest == null)
                {
                    nearest = transform;
                    continue;
                }
                float distance = Vector3.Distance(self.position, transform.position);
                if(distance < minimalDistance)
                {
                    nearest = transform;
                }
            }
            return nearest;
        }
    }

}