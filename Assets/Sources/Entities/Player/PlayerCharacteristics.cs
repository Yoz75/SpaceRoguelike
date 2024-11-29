using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// All player characteristics including name.
    /// </summary>
    public class PlayerCharacteristics : ScriptableObject
    {
        public string Name;
        public float MaximalHealth;
        public float MaximalSpeed;
        public float Impulse;
        public float RotationSpeed;
    }
}