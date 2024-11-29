using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// The player themself.
    /// </summary>
    public class Player : Entity
    {
        [SerializeField] private GameObject DefeatScreen;
        private PlayerCharacteristics RealCharacteristics;
        public PlayerCharacteristics Characteristics
        {
            get
            {
                return RealCharacteristics;
            }
            set
            {
                RealCharacteristics = value;
                SetDependedFields(RealCharacteristics);
            }
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

        /// <summary>
        /// Set fields depended on characteristics (name for example)
        /// </summary>
        /// <param name="characteristics"></param>
        private void SetDependedFields(PlayerCharacteristics characteristics)
        {
            Name = characteristics.Name;
        }
    }
}