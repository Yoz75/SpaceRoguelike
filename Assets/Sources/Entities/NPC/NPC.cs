using System.Collections;
using UnityEngine;
using SpaceRoguelike.Sensors;

namespace SpaceRoguelike.Living
{
    public class NPC : Entity
    {
        private const string PlayerTag = "Player";
        [SerializeField] private NPCCharacteristics Characteristics;
        private IBrains<NPCBrainsInputData, NPCBrainsOutputData> Brains;
        private uint TickIterator;

        public override EntityCharacteristics GetCharacteristics()
        {
            return Characteristics;
        }

        public static NPC Create(GameObject owner, NPCCharacteristics characteristics,
            IBrains<NPCBrainsInputData, NPCBrainsOutputData> brains)
        {
            var npc = owner.AddComponent<NPC>();
            npc.Characteristics = characteristics;
            npc.Brains = brains;
            return npc;
        }

        protected override void OnInit()
        {
            SpriteRenderer renderer = GetComponent<SpriteRenderer>();
            renderer.sprite = Characteristics.Sprite;
            Brains = new PursuerNPCBrain();
            if(Brains == null)
            {
                Debug.LogWarning($"NPC {name} has no brains! Isn`t this a mistake?");
            }
        }

        protected override void OnTick()
        {
            const uint updateFrequency = 2;
            unchecked
            {
                TickIterator++;
            }

            if(TickIterator % updateFrequency == 0)
            {
                NPCBrainsInputData inputData = GetBrainsInputData();
                var outputData = Brains.Think(inputData);
            }
        }

        /// <summary>
        /// Get brains input data to think. Override this method if you create custom AI for NPC
        /// and call base method in start of your method.
        /// </summary>
        /// <returns></returns>
        protected virtual NPCBrainsInputData GetBrainsInputData()
        {
            NPCBrainsInputData inputData = new();
            GameObject player = NearObjectsSensor.GetNearbyObjectOfTag(PlayerTag, transform.position, Characteristics.ViewRadius);
            var nearbyObjects = NearObjectsSensor.GetNearObjectsNearPoint(transform.position, Characteristics.ViewRadius);
            inputData.SelfHealth = Health;

            inputData.NearbyObjects = nearbyObjects.ToArray();
            if(Characteristics.BehaviorType == NPCBehaviorType.Aggressive)
            {
                inputData.Player = player;
            }
            return inputData;
        }

        /// <summary>
        /// React to brains thoughts
        /// </summary>
        /// <param name="data"></param>
        protected virtual void React(NPCBrainsOutputData data)
        {
            return;
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