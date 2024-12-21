using UnityEngine;

namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// Moves body to target
    /// </summary>
    [RequireComponent (typeof(Rigidbody2D))]
    public class PursuerMovement : MonoBehaviour,  IMovement
    {
        public Transform Target;
        private Rigidbody2D Rigidbody;
        private float MaximalSpeed;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
            Rigidbody.linearVelocity = Vector3.zero; //at some reason body still falling even with
            //gravityScale = 0
        }

        public void Move(float xImpulse, float yImpulse)
        {

            Rigidbody.linearVelocity = GetForceToTarget(xImpulse, yImpulse);
            transform.up = -(Target.position - transform.position);
        }

        public void MoveFromTarget(float xImpulse, float yImpulse)
        {
            Rigidbody.linearVelocity = -GetForceToTarget(xImpulse, yImpulse);
            transform.up = Target.position - transform.position;
        }

        public void SetMaximalSpeed(float speed)
        {
            MaximalSpeed = speed;
        }

        private Vector3 GetForceToTarget(float xImpulse, float yImpulse)
        {
            Rigidbody.linearVelocity = Vector2.ClampMagnitude(Rigidbody.linearVelocity, MaximalSpeed);
            Vector2 force = (Target.position - transform.position).normalized;
            force.x *= xImpulse;
            force.y *= yImpulse;
            return force;
        }
        
    }
}
