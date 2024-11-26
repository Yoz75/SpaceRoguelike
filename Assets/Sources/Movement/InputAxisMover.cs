using System;
using UnityEngine;
using SpaceRoguelike.Input;

namespace SpaceRoguelike.Movement
{
    public class InputAxisMover : MonoBehaviour
    {
        [SerializeField] private InputDevice InputDevice;
        private IDirectionalMovement Movement;
        private IRotation Rotation;


        //TODO: Add getting speed from player characteristics
        private float Impulse = 2;
        private float MaximalSpeed = 3;
        private float RotationSpeed = 1;

        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private void Start()
        {
            Rotation = gameObject.AddComponent<Rigidbody2DRotation>();
            switch(InputDevice)
            {
                case InputDevice.Keyboard:
                    Movement = gameObject.AddComponent<Rigidbody2DMovement>();
                    break;
                case InputDevice.UIButtons:
                    //TODO: activating buttons on screen
                    break;
                default:
                    throw new ArgumentException("Unknown device!");
            }
        }

        private void FixedUpdate()
        {
            var verticalAxis = UnityEngine.Input.GetAxis(VerticalAxis);

            Movement.SetMaximalSpeed(MaximalSpeed);

            var horizontalAxis = UnityEngine.Input.GetAxis(HorizontalAxis);

            if(horizontalAxis > 0)
            {
                Rotation.Rotate(-RotationSpeed);
            }
            else if(horizontalAxis < 0)
            {
                Rotation.Rotate(RotationSpeed);
            }

            if(verticalAxis > 0)
            {
                Movement.Move(MoveDirection.Up, Impulse);
            }
            else if(verticalAxis < 0)
            {
                Movement.Move(MoveDirection.Down, Impulse);
            }
        }
    }
}