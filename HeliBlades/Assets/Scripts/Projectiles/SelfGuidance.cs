//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 15:53:19
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
    /// SelfGuidance class.
    /// </summary>
    [CreateAssetMenu(fileName = "SelfGuidance", menuName = "Projectiles/Self Guidance")]
    public class SelfGuidance : ProjectileGuide
    {
#region Public serialized variables
        public float force;
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
            Transform targetTrans = target.value.transform;
            var rigidBody = projInst.GetComponent<Rigidbody>();
            var msg = "No rigidbody component found on projectile. This guidance method requires one.";
            Assert.IsTrue(rigidBody != null, msg);
            while(true)
            {
                Vector3 targetDir = targetTrans.position - projTrans.position;
                Vector3 appliedForce = targetDir.normalized * force * Time.fixedDeltaTime;
                rigidBody.AddForce(appliedForce, ForceMode.Force);
                projTrans.LookAt(projTrans.position + rigidBody.velocity);
                yield return new WaitForFixedUpdate();
            }
        }
    }
}