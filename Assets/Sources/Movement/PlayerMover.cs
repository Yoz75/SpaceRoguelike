using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace SpaceRoguelike.Movement
{
    /// <summary>
    /// Moves gameobject, when get input from axis or ui button
    /// </summary>
    public class PlayerMover : MonoBehaviour
    {
        [SerializeField] private InputDevice InputDevice;
        [SerializeField] private GameObject InputButtonsCanvas;
        private IDirectionalMovement Movement;
        private IRotation Rotation;

        private const string RotateLeftButtonTag = "RotateLeftButton";
        private const string RotateRightButtonTag = "RotateRightButton";
        private const string MoveForwardButtonTag = "MoveForwardButton";
        private const string MoveBackButtonTag = "MoveBackButton";

        private EventTrigger MoveForwardButton, MoveBackButton, RotateLeftButton, RotateRightButton;
        private bool HasActivatedButtons = false;
        private bool IsShallMoveForward, IsShallMoveBack, IsShallRotateLeft, IsShallRotateRight;

        //TODO: Add getting speed from player characteristics
        private float Impulse = 2;
        private float MaximalSpeed = 3;
        private float RotationSpeed = 1;

        private const string HorizontalAxis = "Horizontal";
        private const string VerticalAxis = "Vertical";

        private void Start()
        {
            Rotation = GetComponent<Rigidbody2DRotation>();
            Movement = GetComponent<Rigidbody2DMovement>();
            Rotation ??= gameObject.AddComponent<Rigidbody2DRotation>();
            Movement ??= gameObject.AddComponent<Rigidbody2DMovement>();

            switch(InputDevice)
            {
                case InputDevice.Keyboard:
                    InputButtonsCanvas.SetActive(false);
                    break;
                case InputDevice.UIButtons:
                    InputButtonsCanvas.SetActive(true);
                    //TODO: activating buttons on screen
                    MoveForwardButton = GameObject.FindGameObjectWithTag(MoveForwardButtonTag).GetComponent<EventTrigger>();
                    RotateRightButton = GameObject.FindGameObjectWithTag(RotateRightButtonTag).GetComponent<EventTrigger>();
                    RotateLeftButton = GameObject.FindGameObjectWithTag(RotateLeftButtonTag).GetComponent<EventTrigger>();
                    MoveBackButton = GameObject.FindGameObjectWithTag(MoveBackButtonTag).GetComponent<EventTrigger>();
                    if(!HasActivatedButtons)
                    {
                        ActivateButtons();
                    }
                    break;
                default:
                    throw new ArgumentException("Unknown device!");
            }
            StartCoroutine(TryMove());
        }

        private void ActivateButtons()
        {
            void AddListener(EventTrigger trigger, EventTriggerType triggerType, Action action)
            {
                EventTrigger.Entry entry = new EventTrigger.Entry();
                entry.eventID = triggerType;
                entry.callback.AddListener((_) => { action(); });
                trigger.triggers.Add(entry);
            }

            HasActivatedButtons = true;

            //Kostyli
            AddListener(MoveForwardButton, EventTriggerType.PointerEnter, () => { IsShallMoveForward = true; });
            AddListener(MoveBackButton, EventTriggerType.PointerEnter, () => { IsShallMoveBack = true; });
            AddListener(RotateLeftButton, EventTriggerType.PointerEnter, () => { IsShallRotateLeft = true; });
            AddListener(RotateRightButton, EventTriggerType.PointerEnter, () => { IsShallRotateRight = true; });

            AddListener(MoveForwardButton, EventTriggerType.PointerExit, () => { IsShallMoveForward = false; });
            AddListener(MoveBackButton, EventTriggerType.PointerExit, () => { IsShallMoveBack = false; });
            AddListener(RotateLeftButton, EventTriggerType.PointerExit, () => { IsShallRotateLeft = false; });
            AddListener(RotateRightButton, EventTriggerType.PointerExit, () => { IsShallRotateRight = false; });
        }
        private void FixedUpdate()
        {
            var verticalAxis = UnityEngine.Input.GetAxis(VerticalAxis);

            Movement.SetMaximalSpeed(MaximalSpeed);

            var horizontalAxis = UnityEngine.Input.GetAxis(HorizontalAxis);

            //When we get input from axis, we don`t care about UI buttons, 
            //so we set every variable to false to normally process axis
            if(verticalAxis != 0 || horizontalAxis != 0)
            {
                IsShallMoveForward = false;
                IsShallMoveBack = false;
                IsShallRotateLeft = false;
                IsShallRotateRight = false;
            }

            if(horizontalAxis > 0)
            {
                IsShallRotateLeft = true;
            }
            else if(horizontalAxis < 0)
            {
                IsShallRotateRight = true;
            }

            if(verticalAxis > 0)
            {
                IsShallMoveForward = true;
            }
            else if(verticalAxis < 0)
            {
                IsShallMoveBack = true;
            }
        }

        private IEnumerator TryMove()
        {
            while(true)
            {
                if(IsShallRotateLeft)
                {
                    RotateLeft();
                }
                else if(IsShallRotateRight)
                {
                    RotateRight();
                }

                if(IsShallMoveForward)
                {
                    MoveForward();
                }
                else if(IsShallMoveBack)
                {
                    MoveBack();
                }

                yield return new WaitForFixedUpdate();
            }
        }

        private void MoveBack()
        {
            Movement.Move(MoveDirection.Down, Impulse);
        }

        private void MoveForward()
        {
            Movement.Move(MoveDirection.Up, Impulse);
        }

        private void RotateRight()
        {
            Rotation.Rotate(-RotationSpeed);
        }

        private void RotateLeft()
        {
            Rotation.Rotate(RotationSpeed);
        }
    }
}