using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// All player characteristics including name.
    /// </summary>
    [CreateAssetMenu(fileName ="NewPlayer", menuName ="SpaceRoguelike/entity characteristics/new player")]
    public class PlayerCharacteristics : EntityCharacteristics
    {
        public Sprite Sprite;
        public float MaximalSpeed;
        public float Impulse;
        public float RotationSpeed;
    }
}