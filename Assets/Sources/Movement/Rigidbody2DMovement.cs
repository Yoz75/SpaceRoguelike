using System;
using UnityEngine;

namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// Moves gameobject in one of directions listed in <see cref="MoveDirection"/> by adding force to
    /// Rigidbody2D
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rigidbody2DMovement : MonoBehaviour, IMovement
    {
        private Rigidbody2D Rigidbody;
        private float MaximalSpeed = float.PositiveInfinity;

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
        }

        public void SetMaximalSpeed(float speed)
        {
            MaximalSpeed = speed;
        }

        public void Move(float xImpulse, float yImpulse)
        {
            Rigidbody.linearVelocity = Vector2.ClampMagnitude(Rigidbody.linearVelocity, MaximalSpeed);
            Vector2 force = new Vector2(xImpulse, yImpulse);

            Rigidbody.AddRelativeForce(force);
        }
    }
}