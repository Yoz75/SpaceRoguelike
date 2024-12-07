
namespace SpaceRoguelike.Living
{
    public class PursuerNPCBrain : IBrains<NPCBrainsInputData, NPCBrainsOutputData>
    {
        public NPCBrainsOutputData Think(NPCBrainsInputData input)
        {
            NPCBrainsOutputData output = new NPCBrainsOutputData();

            if(input.Target == null)
            {
                output.Action = NPCBrainsOutputData.NPCAction.DoNothing;
            }

            var healthPercentage = input.SelfHealth / input.MaximalHealth;

            if(healthPercentage > input.HealthPercentageRunawayThreshold)
            {
                output.Action = NPCBrainsOutputData.NPCAction.RunToTarget;
            }
            else
            {
                output.Action = NPCBrainsOutputData.NPCAction.RunFromTarget;
            }

            return output;
        }
    }
}