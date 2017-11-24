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
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        public void Update()
        {
            if(lookTarget != null)
            {
                var lookRot = Quaternion.LookRotation(lookTarget.position - transform.position);
                float t = turnRate * Time.deltaTime;
                transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, t);
            }
        }
#endregion
    }
}