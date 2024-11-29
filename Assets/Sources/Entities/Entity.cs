using UnityEngine;

namespace SpaceRoguelike
{
    /// <summary>
    /// Base class for all alive-like things
    /// </summary>
    public abstract class Entity : MonoBehaviour, IDamageable, IHealable
    {
        public float Health
        {
            get;
            private set;
        }

        public float MaximalHealth
        {
            get;
            private set;
        }

        public string Name
        {
            get;
            protected set;
        }

        /// <summary>
        /// Damage this entity.
        /// Aren't you ashamed to offend this little entity!?!!??!?!
        /// </summary>
        /// <param name="damage"></param>
        public void TakeDamage(float damage)
        {
            if(Health < damage)
            {
                Die();
                return;
            }
            Health -= damage;
        }

        /// <summary>
        /// Set maximal health to <paramref name="health"/>. 
        /// If new value less than health, it will cut off health to 
        /// new maximal health
        /// </summary>
        /// <param name="health">new maximal health</param>
        protected void SetMaximalHealth(float health)
        {
            MaximalHealth = health;
            if(Health > MaximalHealth)
            {
                Health = MaximalHealth;
            }
        }

        public void Heal(float health)
        {
            Health += health;
            if(Health > MaximalHealth)
            {
                Health = MaximalHealth;
            }
        }

        /// <summary>
        /// Great! You killed that entity! Are you happy now?
        /// </summary>
        protected abstract void Die();

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
