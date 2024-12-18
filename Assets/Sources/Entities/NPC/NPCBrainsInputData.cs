using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// Input data for NPC's brains.
    /// </summary>
    public struct NPCBrainsInputData
    {
        public GameObject[] NearbyObjects;
        public GameObject Target;
        public GameObject Player;
        public float SelfHealth;
        public float MaximalHealth;
        /// <summary>
        /// NPC will run from player when health below this percent of maximal health
        /// </summary>
        [Range(0f, 1f)]
        public float HealthPercentageRunawayThreshold;
        /// <summary>
        /// If true, entity will run from player if health below <see cref="HealthPercentageRunawayThreshold"/> 
        /// </summary>
        public bool IsShy;
    }
}