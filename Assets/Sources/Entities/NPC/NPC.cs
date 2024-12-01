using System.Collections;
using UnityEngine;


namespace SpaceRoguelike
{
    public class NPC : Entity
    {
        [SerializeField] private NPCCharacteristics Characteristics;

        public override EntityCharacteristics GetCharacteristics()
        {
            return Characteristics;
        }

        protected override void OnInit()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = Characteristics.Sprite;
        }

        protected override void Die()
        {
            StartCoroutine(Dying());
        }

        protected override void OnCollisionWithOther(Entity other)
        {
            if(Characteristics.BehaviorType == NPCBehaviorType.Aggressive && other is Player player)
            {
                player.TakeDamage(Characteristics.Damage);
            }
        }

        private IEnumerator Dying()
        {
            const float dyingTime = 0.5f;
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            
            if(spriteRenderer != null)
            {
                spriteRenderer.color = Color.red;
                yield return new WaitForSeconds(dyingTime);
                Destroy(gameObject);
            }           
        }
    }
}