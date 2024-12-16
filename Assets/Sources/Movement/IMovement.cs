
namespace SpaceRoguelike.Movement
{
    public interface IMovement
    {
        public void SetMaximalSpeed(float speed);
        public void Move(float xImpulse, float yImpulse);
    }
}