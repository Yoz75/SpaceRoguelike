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

        /// <summary>
        ///Get the nearest transform to <paramref name = "self"/> from list of game objects with attached <paramref name="components"/>   
        /// </summary>
        /// <param name="self"></param>
        /// <param name="components"></param>
        /// <returns></returns>
        public static Transform GetNearest(Transform self,params MonoBehaviour[] components)
        {
            Transform[] transforms = new Transform[components.Length];

            for(int i = 0; i < transforms.Length; i++)
            {
                transforms[i] = components[i].transform;
            }
            return GetNearest(self, transforms);
        }

        /// <summary>
        ///Get the nearest transform to <paramref name = "self"/> from <paramref name="gameObjects"/> transforms  
        /// </summary>
        /// <param name="self"></param>
        /// <param name="gameObjects"></param>
        /// <returns></returns>
        public static Transform GetNearest(Transform self, params GameObject[] gameObjects)
        {
            Transform[] transforms = new Transform[gameObjects.Length];

            for(int i = 0; i < transforms.Length; i++)
            {
                transforms[i] = gameObjects[i].transform;
            }
            return GetNearest(self, transforms);
        }
    }

}