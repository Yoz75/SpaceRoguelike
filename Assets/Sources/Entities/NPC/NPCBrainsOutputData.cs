
namespace SpaceRoguelike
{
    public struct NPCBrainsOutputData
    {
        public enum NPCAction
        {
            DoNothing = 0,
            RunToTarget,
            RunFromTarget
        }
        public NPCAction Action;
    }
}
