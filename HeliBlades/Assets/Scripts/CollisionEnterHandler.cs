//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 00:00:55
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;



namespace HeliBlades
{
    /// <summary>
    /// CollisionEnterHandler class.
    /// </summary>
    public class CollisionEnterHandler : MonoBehaviour
    {
#region Public serialized variables
        public UnityEvent onCollisionEnterResponce;
        // public UnityEvent onCollisionExit;
        // public UnityEvent onTriggerEnter;
        // public UnityEvent onTriggerExit;
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void OnCollisionEnter(Collision collision)
        {
            onCollisionEnterResponce.Invoke();
        }

        // private void OnCollisionExit(Collision collision)
        // {
        //     onCollisionExit.Invoke();
        // }

        // private void OnTriggerEnter(Collider collider)
        // {
        //     onTriggerEnter.Invoke();
        // }

        // private void OnTriggerExit(Collider collider)
        // {
        //     onTriggerExit.Invoke();
        // }
#endregion
    }
}