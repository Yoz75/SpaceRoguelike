using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// The player themself.
    /// </summary>
    public class Player : Entity
    {
        [SerializeField] private GameObject DefeatScreen;
        private PlayerCharacteristics Characteristics;

        public override EntityCharacteristics GetCharacteristics()
        {
            return Characteristics;
        }

        protected override void Die()
        {
            DefeatScreen.SetActive(true);
        }

        private void Start()
        {
            DefeatScreen.SetActive(false);
            Heal(float.MaxValue);
        }
    }
}