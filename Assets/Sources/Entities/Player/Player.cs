using System;
using UnityEngine;

namespace SpaceRoguelike.Living
{
    /// <summary>
    /// The player themself.
    /// </summary>
    public class Player : Entity
    {
        [SerializeField] private GameObject DefeatScreen;
        [SerializeField] private PlayerCharacteristics Characteristics;

        const string PlayerTag = "Player";

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
            if(gameObject.tag != PlayerTag)
            {
                gameObject.tag = PlayerTag;
            }
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if(renderer == null)
            {
                throw new NullReferenceException("Player has no sprite renderer!");
            }
            renderer.sprite = Characteristics.Sprite;
            DefeatScreen.SetActive(false);
            Heal(float.MaxValue);
        }
    }
}