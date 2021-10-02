﻿using UnityEngine;

namespace Gameplay.ShipSystems
{
    public class MovementSystem : MonoBehaviour
    {

        [SerializeField]
        private float _lateralMovementSpeed;
        
        [SerializeField]
        private float _longitudinalMovementSpeed;
    
        public void loadMove()
        {
            _lateralMovementSpeed = 250.0f;
        }
        public void LateralMovement(float amount)
        {
            if (tag == "bonus") { if (transform.position.y < -16) { } else { Move(amount * _longitudinalMovementSpeed, Vector3.up); } }
            else Move(amount * _lateralMovementSpeed, Vector3.right);
        }

        public void LongitudinalMovement(float amount)
        {
            if (tag == "bonus") { if (transform.position.y < -16) { } else { Move(amount * _longitudinalMovementSpeed, Vector3.up); } }
            else { Move(amount * _longitudinalMovementSpeed, Vector3.up); }
        }
        public void HorizontalMovement(float amount)
        {
            if (tag == "bonus") { if (transform.position.y < -16) { } else { Move(amount * _longitudinalMovementSpeed, Vector3.up); } }
            else Move(amount * _longitudinalMovementSpeed, Vector3.left);
        }

        private void Move(float amount, Vector3 axis)
        {
            transform.Translate(amount * axis.normalized);
        }
    }
}
