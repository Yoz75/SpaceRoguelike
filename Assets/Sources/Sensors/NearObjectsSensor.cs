using System.Collections.Generic;
using UnityEngine;


namespace SpaceRoguelike.Sensors
{
    /// <summary>
    /// Finds objects near position
    /// </summary>
    public static class NearObjectsSensor
    {
        const uint RaycastRaysCount = 16;
        /// <summary>
        /// Get all nearby objects near <paramref name="point"/>
        /// </summary>
        /// <param name="point"></param>
        /// <param name="distance">object search distance</param>
        /// <returns></returns>
        public static List<GameObject> GetNearObjectsToPoint(Vector2 point, float distance)
        {
            List<GameObject> nearObjects = null;
            const uint angleStep = 360 / RaycastRaysCount;

            for(int i = 0; i < RaycastRaysCount; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                RaycastHit2D hit = new();
                hit = Physics2D.Raycast(point, direction, distance);
                nearObjects.Add(hit.collider.gameObject);
            }

            return nearObjects;
        }

        /// <summary>
        /// Get component <typeparamref name="T"/> if there is game object with this component nearby
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>null when there is no object with component <typeparamref name="T"/> and vice versa</returns>
        public static T GetNearbyOfComponent<T>(Vector2 point, float distance) where T : MonoBehaviour
        {
            const uint angleStep = 360 / RaycastRaysCount;

            for(int i = 0; i < RaycastRaysCount; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                RaycastHit2D hit = new();
                hit = Physics2D.Raycast(point, direction, distance);

                T component = hit.collider.gameObject.GetComponent<T>();

                if(component != null)
                {
                    return component;
                }
            }
            return null;
        }

        public static GameObject GetNearbyObjectOfTag(string tag, Vector2 point, float distance)
        {
            const uint angleStep = 360 / RaycastRaysCount;

            for(int i = 0; i < RaycastRaysCount; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                RaycastHit2D hit = new();
                hit = Physics2D.Raycast(point, direction, distance);

                GameObject obj = hit.collider.gameObject;

                if(obj.tag == tag)
                {
                    return obj;
                }
            }
            return null;
        }
    }
}