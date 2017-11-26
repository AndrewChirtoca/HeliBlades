//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 04:17:47
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// ProjectileLauncher class.
    /// </summary>
    public class ProjectileLauncher : MonoBehaviour
    {
#region Public serialized variables
        public GameObjectVariable target;
        public ProjectileFlight projectilePrefab;
        public Transform launchPod;
        public KeyCode trigger;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void LaunchProjectile()
        {
            if(!PreLaunchCheck())
            {
                var msg = "Pre launch check failed. The target seems invalid. Aborting.";
                Debug.LogWarning(msg);
                return;
            }

            var pos = launchPod.position;
            var rot = launchPod.rotation;
            var instance = Instantiate(projectilePrefab, pos, rot);
            instance.Launch(target);
        }
#endregion



#region Monobehavior methods
        private void Update()
        {
            if(Input.GetKeyDown(trigger))
            {
                LaunchProjectile();
            }
        }
#endregion


        private bool PreLaunchCheck()
        {
            bool targetRefOK = (target != null);
            bool targetValOK = (target.value != null);
            return targetRefOK && targetValOK;
        }
    }
}