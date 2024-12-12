
namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// A thing that can move in one of directions, listed in <see cref="MoveDirection"/>
    /// </summary>
    public interface IDirectionalMovement : IMovement
    {
        public MoveDirection Direction
        {
            get;
            set;
        }
    }
}