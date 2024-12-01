using UnityEngine;

namespace SpaceRoguelike.Living
{
    [CreateAssetMenu(fileName = "NewEntity", menuName = "SpaceRoguelike/entity characteristics/new entity")]
    public class EntityCharacteristics : ScriptableObject
    {
        public string Name;
        public float MaximalHealth;
        public float Damage;
        /// <summary>
        /// Color that applies to entity when it was hit
        /// </summary>
        public Color DamageColor = Color.red;

        /// <summary>
        /// How much will <see cref="DamageColor"/> influence on texture color
        /// </summary>
        [Range(0f, 1f)]
        public float DamageColorInfluence = 0.5f;

        /// <summary>
        /// Time in seconds, how long <see cref="DamageColor"/> will be applied
        /// </summary>
        public float TakingDamageTime = 0.1f;
    }
}