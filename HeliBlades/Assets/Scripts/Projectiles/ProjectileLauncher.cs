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
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void LaunchProjectile()
        {
            var pos = transform.TransformPoint(new Vector3(2.8f, -1.0f, 2.0f));
            var instance = Instantiate(projectilePrefab, pos, transform.rotation);
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