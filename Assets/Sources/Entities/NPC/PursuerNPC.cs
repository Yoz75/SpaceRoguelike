
using NUnit.Framework.Constraints;
using SpaceRoguelike.Helpers;
using SpaceRoguelike.Movement;
using UnityEngine;

namespace SpaceRoguelike.Living
{
    public class PursuerNPC : NPC
    {
        private PursuerMovement Movement;

        protected override void OnInit()
        {
            Brains = new PursuerNPCBrain();
            base.OnInit();
            Movement = GetComponent<PursuerMovement>();
            if(Movement == null)
            {
                Movement = gameObject.AddComponent<PursuerMovement>();
            }

            Movement.Target = GetNearestPlayerTransform();
        }

        protected override NPCBrainsInputData GetBrainsInputData()
        {
            var data = base.GetBrainsInputData();
            data.Target = data.Player;
            return data;
        }

        protected override void React(NPCBrainsOutputData data)
        {
            switch(data.Action)
            {
                case NPCBrainsOutputData.NPCAction.DoNothing:
                    return;
                case NPCBrainsOutputData.NPCAction.RunToTarget:
                    if(Movement.Target == null)
                    {
                        Movement.Target = GetNearestPlayerTransform();
                    }
                    Movement.Move(Characteristics.Speed, Characteristics.Speed);
                    break;
                case NPCBrainsOutputData.NPCAction.RunFromTarget:
                    if(Movement.Target == null)
                    {
                        Movement.Target = GetNearestPlayerTransform();
                    }
                    Movement.MoveFromTarget(Characteristics.Speed, Characteristics.Speed);
                    break;
                default:
                    break;
            }
        }

        private Transform GetNearestPlayerTransform()
        {
            Transform[] playersTransforms = new Transform[Player.Players.Count];
            for(int i = 0; i < playersTransforms.Length; i++)
            {
                playersTransforms[i] = Player.Players[i].transform;
            }

            return TransformHelper.GetNearest(transform, playersTransforms);
        }
    }
}