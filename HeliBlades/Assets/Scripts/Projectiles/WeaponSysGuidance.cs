//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 17:01:27
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Assertions;



namespace HeliBlades
{
    /// <summary>
    /// WeaponSySGuidance class.
    /// </summary>
    [CreateAssetMenu(fileName = "WeaponSysGuidance", menuName = "Projectiles/Weapon Sys Guidance")]
    public class WeaponSySGuidance : ProjectileGuide
    {
#region Public serialized variables
        public float force;
        public ForceMode mode;
#endregion



#region Private variables

#endregion



#region Public methods and properties
#endregion



#region ScriptableObject methods
#endregion

        public override IEnumerator GuidanceRoutine(GameObject projInst, GameObjectVariable target)
        {
            Transform projTrans = projInst.transform;
            var rigidBody = projInst.GetComponent<Rigidbody>();
            var msg = "No rigidbody component found on projectile. This guidance method requires one.";
            Assert.IsTrue(rigidBody != null, msg);
            Vector3 targetPos = target.value.transform.position;
            while(true)
            {
                if(target.value != null)
                {
                    targetPos = target.value.transform.position;
                }
                Vector3 targetDir = targetPos - projTrans.position;
                Vector3 appliedForce = targetDir.normalized * force * Time.fixedDeltaTime;
                projTrans.LookAt(projTrans.position + rigidBody.velocity);
                rigidBody.AddForce(appliedForce, mode);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}