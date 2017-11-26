﻿//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-21 22:33:44
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;



namespace HeliBlades
{
    /// <summary>
    /// VehicleSteering class.
    /// </summary>
    public class VehicleSteering : MonoBehaviour
    {
#region Public serialized variables
        //public Transform vehicleTransform;
        public float mass = 100.0f;
        public float maxVelocity = 30.0f;
        public float maxForce = 500.0f;
        public float stopRadius = 1.0f;
        public float breakRadius = 10.0f;
        //public float velocityMagnitude;


        public bool freezeX;
        public bool freezeY;
        public bool freezeZ;
#endregion



#region Private variables
        private Vector3 _velocity;
        private Coroutine _moveRoutineInstance;
#endregion



#region Public methods and properties
        [ContextMenu("Move To Origin")]
        public void MoveToOrigin()
        {
            MoveTo(Vector3.zero);
        }

        public void MoveTo(Vector3Variable target)
        {
            MoveTo(target.value);
        }

        public void MoveTo(Vector3 target)
        {
            if(_moveRoutineInstance != null)
            {
                StopCoroutine(_moveRoutineInstance);
            }

            _moveRoutineInstance = StartCoroutine(MoveToRoutine(target));
        }

        public void Stop()
        {
            if(_moveRoutineInstance != null)
            {
                StopCoroutine(_moveRoutineInstance);
            }

            _velocity = Vector3.zero;
        }
#endregion

        private IEnumerator MoveToRoutine(Vector3 target)
        {
            float targetDistance;
            Vector3 currPos = transform.position;

            target = new Vector3(
                (freezeX) ? currPos.x : target.x,
                (freezeY) ? currPos.y : target.y,
                (freezeZ) ? currPos.z : target.z);

            do
            {
                targetDistance = Vector3.Distance(transform.position, target);
                Vector3 targetDirection = (target - transform.position).normalized;
                Vector3 desiredVelocity = targetDirection * maxVelocity;
                Vector3 steering = desiredVelocity - _velocity;

                steering = Vector3.ClampMagnitude(steering, maxForce);
                steering = steering / mass;

                float velocityCoeficient = Mathf.Clamp01(targetDistance / breakRadius);
                _velocity = Vector3.ClampMagnitude(_velocity + steering , maxVelocity * velocityCoeficient);
                transform.position += _velocity * Time.deltaTime;
                transform.rotation = Quaternion.LookRotation(_velocity);
                //velocityMagnitude = _velocity.magnitude;

                yield return null;
            }
            while(targetDistance > stopRadius);

            Stop();
        }

#region Monobehavior methods
#endregion
    }
}