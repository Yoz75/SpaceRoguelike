using System;
using System.Collections.Generic;
using UnityEngine;

namespace SpaceRoguelike.Living
{
    /// <summary>
    /// The player themself.
    /// </summary>
    public class Player : Entity
    {
        public static List<Player> Players = new List<Player>();
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
            Players.Add(this);
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
        }
    }
}