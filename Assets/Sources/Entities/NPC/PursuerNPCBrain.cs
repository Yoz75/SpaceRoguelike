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

            if(input.IsShy)
            {

                var healthPercentage = input.SelfHealth / input.MaximalHealth;
                if(healthPercentage > input.HealthPercentageRunawayThreshold)
                {
                    output.Action = NPCBrainsOutputData.NPCAction.RunToTarget;
                }
                else
                {
                    output.Action = NPCBrainsOutputData.NPCAction.RunFromTarget;
                }
            }
            else
            {
                output.Action = NPCBrainsOutputData.NPCAction.RunToTarget;
            }

            return output;
        }
    }
}