
namespace SpaceRoguelike
{
    /// <summary>
    /// Brains that make a decision of type <see cref="TDecision"/>
    /// based on info of type <see cref="TInfo"/>
    /// </summary>
    /// <typeparam name="TInfo"></typeparam>
    /// <typeparam name="TSolution"></typeparam>
    public interface IBrains<TInfo, TDecision>
    {
        public TDecision Think(TInfo inputInfo);
    }
}