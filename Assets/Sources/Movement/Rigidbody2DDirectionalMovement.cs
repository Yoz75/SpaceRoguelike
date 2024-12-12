using System;
using UnityEngine;

namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// Moves gameobject in one of directions listed in <see cref="MoveDirection"/> by adding force to
    /// Rigidbody2D
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rigidbody2DDirectionalMovement : MonoBehaviour, IDirectionalMovement
    {
        private Rigidbody2D Rigidbody;
        private float MaximalSpeed = float.PositiveInfinity;
                
        MoveDirection IDirectionalMovement.Direction
        { 
            get;
            set;
        }

        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
            Rigidbody.gravityScale = 0;
        }

        public void SetMaximalSpeed(float speed)
        {
            MaximalSpeed = speed;
        }

        public void Move(float impulse)
        {
            Rigidbody.linearVelocity = Vector2.ClampMagnitude(Rigidbody.linearVelocity, MaximalSpeed);
            Vector2 force = DirectionToVector2(((IDirectionalMovement)this).Direction) * impulse;

            Rigidbody.AddRelativeForce(force);
        }

        private Vector2 DirectionToVector2(MoveDirection direction)
        {
            switch(direction)
            {
                case MoveDirection.Unknown:
                    throw new ArgumentException("move direction is None!");
                case MoveDirection.Up:
                    return Vector2.up;
                case MoveDirection.Down:
                    return Vector2.down;
                case MoveDirection.Left:
                    return Vector2.left;
                case MoveDirection.Right:
                    return Vector2.right;
                default:
                    throw new ArgumentException($"unexpected enum value: {direction}");
            }
        }
    }
}