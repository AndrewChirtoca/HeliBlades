//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-23 01:15:15
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.AI;



namespace HeliBlades
{
    /// <summary>
    /// MouseRaycaster class.
    /// </summary>
    public class MouseRaycaster : MonoBehaviour
    {
#region Public serialized variables
        public NavMeshAgent agent;
        public Camera raycastCamera;
        public bool fallbackOnMainCam = true;
        public KeyCode trigger;
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void Update()
        {
            if(raycastCamera == null && fallbackOnMainCam)
            {
                raycastCamera = Camera.main;
            }

            if (Input.GetKey(trigger))
            {
                RaycastHit hit;

                if (Physics.Raycast(raycastCamera.ScreenPointToRay(Input.mousePosition), out hit, 100))
                {
                    agent.destination = hit.point;
                }
            }
        }
#endregion
    }
}