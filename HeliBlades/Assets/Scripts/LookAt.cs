//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    Insert datetime string (⇧⌘I or Ctrl+Shift+I)
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// LookAt class.
    /// </summary>
    public class LookAt : MonoBehaviour
    {
#region Public serialized variables
        public Transform lookTarget;
        public float turnRate;
        public bool freezeRotX = false;
        public bool freezeRotY = false;
        public bool freezeRotZ = false;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void SetLookTarget(Transform target)
        {
            lookTarget = target;
        }

        public void SetLookTarget(GameObjectVariable target)
        {
            lookTarget = (target.value != null) ? target.value.transform : null;
        }
#endregion



#region Monobehavior methods
        private void Update()
        {
            if(lookTarget != null)
            {
                var lookRot = Quaternion.LookRotation(lookTarget.position - transform.position);
                float t = turnRate * Time.deltaTime;
                var newRotation = Quaternion.Slerp(transform.rotation, lookRot, t);
                Vector3 oldEulerRot = transform.rotation.eulerAngles;
                Vector3 newEulerRot = newRotation.eulerAngles;
                newRotation = Quaternion.Euler(
                    (freezeRotX) ? oldEulerRot.x : newEulerRot.x,
                    (freezeRotY) ? oldEulerRot.y : newEulerRot.y,
                    (freezeRotZ) ? oldEulerRot.z : newEulerRot.z);
                transform.rotation = newRotation;
            }
        }
#endregion
    }
}