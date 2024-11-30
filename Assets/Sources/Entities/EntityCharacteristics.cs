using UnityEngine;

namespace SpaceRoguelike
{
    [CreateAssetMenu(fileName = "NewEntity", menuName = "SpaceRoguelike/entity characteristics/new entity")]
    public class EntityCharacteristics : ScriptableObject
    {
        public string Name;
        public float MaximalHealth;
        public float Damage;
    }
}