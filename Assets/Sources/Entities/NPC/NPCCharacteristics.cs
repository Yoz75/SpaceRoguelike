
using UnityEngine;

namespace SpaceRoguelike
{    
    [CreateAssetMenu(fileName = "NewNPC", menuName = "SpaceRoguelike/entity characteristics/new NPC")]
    public class NPCCharacteristics : EntityCharacteristics
    {
        public Sprite Sprite;
        public NPCBehaviorType BehaviorType;
    }
}