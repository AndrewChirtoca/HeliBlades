//===----------------------------------------------------------------------===//
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
        public Transform vehicleTransform;
        public float mass = 100.0f;
        public float maxVelocity = 30.0f;
        public float maxForce = 500.0f;
        public float stopRadius = 1.0f;
        public float breakRadius = 100.0f;
#endregion



#region Private variables
        private Vector3 _velocity;
        private Coroutine _moveRoutineInstance;
#endregion



#region Public methods and properties
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

            do
            {
                targetDistance = Vector3.Distance(vehicleTransform.position, target);
                float velocityCoeficient = Mathf.Clamp01(targetDistance / breakRadius);
                Vector3 targetDirection = (target - vehicleTransform.position).normalized;
                Vector3 desiredVelocity = targetDirection * maxVelocity * velocityCoeficient;
                Vector3 steering = desiredVelocity - _velocity;

                steering = Vector3.ClampMagnitude(steering, maxForce);
                steering = steering / mass;

                _velocity = Vector3.ClampMagnitude(_velocity + steering , maxVelocity);
                vehicleTransform.position += _velocity * Time.deltaTime;
                vehicleTransform.rotation = Quaternion.LookRotation(_velocity);

                yield return null;
            }
            while(targetDistance > stopRadius);

            Stop();
        }

#region Monobehavior methods
#endregion
    }
}