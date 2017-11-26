//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 23:57:34
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Assertions;



namespace HeliBlades
{
    /// <summary>
    /// VehicleMovement class.
    /// </summary>
    public class VehicleMovement : MonoBehaviour
    {
#region Public serialized variables
        public float speed = 25f;
        public float turnSpeed = 90f;
#endregion



#region Private variables
        private string _movementAxisName = "Vertical";
        private string _turnAxisName = "Horizontal";
        private Rigidbody _rigidbody;
        private float _movementInputValue;
        private float _turnInputValue;
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void Awake ()
        {
            _rigidbody = GetComponent<Rigidbody>();
            var msg = "VehicleMovement requires a rigid body component on the game object.";
            Assert.IsTrue(_rigidbody != null, msg);
        }

        private void OnEnable ()
        {
            _movementInputValue = 0f;
            _turnInputValue = 0f;
        }

        private void FixedUpdate ()
        {
            _movementInputValue = Input.GetAxis (_movementAxisName);
            _turnInputValue = Input.GetAxis (_turnAxisName);

            Vector3 movement = transform.forward * _movementInputValue * speed * Time.deltaTime;
            _rigidbody.MovePosition(_rigidbody.position + movement);

            float turn = _turnInputValue * turnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler (0f, turn, 0f);
            _rigidbody.MoveRotation(_rigidbody.rotation * turnRotation);
        }
#endregion
    }
}