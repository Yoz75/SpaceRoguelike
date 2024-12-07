using System.Collections.Generic;
using UnityEngine;


namespace SpaceRoguelike.Sensors
{
    /// <summary>
    /// Finds objects near position
    /// </summary>
    public static class NearObjectsSensor
    {
        public static List<GameObject> GetNearObjectsToPoint(Vector2 point, float distance)
        {
            List<GameObject> nearObjects = null;
            const uint raysCount = 48;
            const uint angleStep = 360 / raysCount;

            for(int i = 0; i < raysCount; i++)
            {
                float angle = i * angleStep * Mathf.Deg2Rad;
                Vector2 direction = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle));

                RaycastHit2D hit = new();
                hit = Physics2D.Raycast(point, direction, distance);
                nearObjects.Add(hit.collider.gameObject);
            }

            return nearObjects;
        }
    }
}