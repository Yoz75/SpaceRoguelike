
using UnityEngine;

namespace SpaceRoguelike.Living
{    
    [CreateAssetMenu(fileName = "NewNPC", menuName = "SpaceRoguelike/entity characteristics/new NPC")]
    public class NPCCharacteristics : EntityCharacteristics
    {
        public Sprite Sprite;
        public NPCBehaviorType BehaviorType;
        /// <summary>
        /// NPC run from player when has low health
        /// </summary>
        public bool IsShy;
        public float ViewRadius;
        public float Speed;
        /// <summary>
        /// see <see cref="NPCBrainsInputData.HealthPercentageRunawayThreshold"/>
        /// </summary>
        [Range(0f, 1f)]
        public float HealthPercentageRunawayThreshold;
    }
}