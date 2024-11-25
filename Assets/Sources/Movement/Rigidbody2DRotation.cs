using UnityEngine;

namespace SpaceRoguelike.Movement
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class Rigidbody2DRotation : MonoBehaviour, IRotation
    {
        private Rigidbody2D Rigidbody;
        private void Start()
        {
            Rigidbody = GetComponent<Rigidbody2D>();
        }

        public void Rotate(float angle)
        {
            Rigidbody.AddTorque(angle);
        }
    }
}