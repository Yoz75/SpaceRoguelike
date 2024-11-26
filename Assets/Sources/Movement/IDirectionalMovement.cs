
namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// A thing that can move in one of directions, listed in <see cref="MoveDirection"/>
    /// </summary>
    public interface IDirectionalMovement
    {
        public void SetMaximalSpeed(float speed);
        public void Move(MoveDirection direction, float impulse);
    }
}