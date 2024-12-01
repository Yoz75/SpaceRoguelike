using System.Collections;
using UnityEngine;

namespace SpaceRoguelike.Living
{
    /// <summary>
    /// Base class for all alive-like things
    /// </summary>
    public abstract class Entity : MonoBehaviour, IDamageable, IHealable
    {
        public abstract EntityCharacteristics GetCharacteristics();

        public float Health
        {
            get;
            private set;
        }

        /// <summary>
        /// Calls when entity is inited
        /// </summary>
        protected virtual void OnInit()
        {
            return;
        }

        /// <summary>
        /// Damage this entity.
        /// Aren't you ashamed to offend this little entity!?!!??!?!
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
            OnTakenDamage(damage);
            if(Health <= damage)
            {
                Die();
                return;
            }
            Health -= damage;
        }

        public void Heal(float health)
        {
            var characteristics = GetCharacteristics();
            Health += health;
            if(Health > characteristics.MaximalHealth)
            {
                Health = characteristics.MaximalHealth;
            }
        }

        /// <summary>
        /// Set maximal health to <paramref name="health"/>. 
        /// If new value less than health, it will cut off health to 
        /// new maximal health
        /// </summary>
        /// <param name="health">new maximal health</param>
        protected void SetMaximalHealth(float health)
        {
            var characteristics = GetCharacteristics();
            characteristics.MaximalHealth = health;
            if(Health > characteristics.MaximalHealth)
            {
                Health = characteristics.MaximalHealth;
            }
        }

        /// <summary>
        /// Great! You killed that entity! Are you happy now?
        /// </summary>
        protected abstract void Die();

        /// <summary>
        /// Calls when entity has taken damage.
        /// </summary>
        /// <param name="damage"></param>
        protected virtual void OnTakenDamage(float damage)
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            if(renderer != null)
            {
                StartCoroutine(TakingDamage(renderer));
            }
            return;
        }

        private IEnumerator TakingDamage(SpriteRenderer renderer)
        {
            var characteristics = GetCharacteristics();
            var startColor = renderer.color;
            renderer.color = Color.Lerp(startColor, characteristics.DamageColor, characteristics.DamageColorInfluence);
            yield return new WaitForSeconds(characteristics.TakingDamageTime);
            renderer.color = startColor;
        }

        /// <summary>
        /// Calls when this entity collides with another entity
        /// </summary>
        /// <param name="other"></param>
        protected virtual void OnCollisionWithOther(Entity other)
        {
            //This method is optional, so we don`t mark it with abstract
            //and just return (otherwise the compiler will complain)
            return;
        }

        private void Start()
        {
            OnInit();
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            var entity = collision.collider.GetComponent<Entity>();

            if(entity != null)
            {
                OnCollisionWithOther(entity);
            }
        }
    }
}
