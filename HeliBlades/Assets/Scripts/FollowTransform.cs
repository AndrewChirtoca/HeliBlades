//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-22 00:43:00
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// FollowTransform class.
    /// </summary>
    public class FollowTransform : MonoBehaviour
    {
#region Public serialized variables
        public Transform followTransform;
        public Vector3 followOffset;
        public float minDistance = 30.0f;
        public float maxDistance = 60.0f;
        public float moveDeltaCoef = 100.0f;
        public float distanceStepPerSec = 0.5f;
#endregion



#region Private variables
        private float _currentOffsetDistance;
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void Update()
        {
            Vector3 normOffsetVec = followOffset.normalized;
            Vector3 newPosition = followTransform.position + normOffsetVec * _currentOffsetDistance;
            float scaledDeltaDist = Vector3.Distance(newPosition, transform.position) * moveDeltaCoef;
            float targetCameraDist = Mathf.Clamp(scaledDeltaDist, minDistance, maxDistance);
            float lerpStep = distanceStepPerSec * Time.deltaTime;

            _currentOffsetDistance = Mathf.Lerp(_currentOffsetDistance, targetCameraDist, lerpStep);

            transform.position = followTransform.position + normOffsetVec * _currentOffsetDistance;
            transform.rotation = Quaternion.LookRotation(followTransform.position - transform.position);
        }
#endregion
    }
}