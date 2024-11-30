using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// The player themself.
    /// </summary>
    public class Player : Entity
    {
        [SerializeField] private GameObject DefeatScreen;
        [SerializeField] private PlayerCharacteristics Characteristics;

        public override EntityCharacteristics GetCharacteristics()
        {
            return Characteristics;
        }

        protected override void Die()
        {
            DefeatScreen.SetActive(true);
        }

        protected override void OnInit()
        {
            DefeatScreen.SetActive(false);
            Heal(float.MaxValue);
        }
    }
}