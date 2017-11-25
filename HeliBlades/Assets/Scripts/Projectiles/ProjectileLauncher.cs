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
        public Projectile projectilePrefab;
        public Transform launchPod;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void LaunchProjectile()
        {
            var pos = launchPod.position;
            var rot = launchPod.rotation;
            var instance = Instantiate(projectilePrefab, pos, rot);
            instance.Launch();
        }
#endregion



#region Monobehavior methods
#endregion

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                LaunchProjectile();
            }
        }
    }
}