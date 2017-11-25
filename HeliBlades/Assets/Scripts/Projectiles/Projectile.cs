//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 04:56:39
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;



namespace HeliBlades
{
    /// <summary>
    /// Projectile class.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
#region Public serialized variables
        public GameObjectVariable target;
        public ProjectileGuide guidence;
        public UnityEvent onLaunch;
        public UnityEvent onCollision;
#endregion



#region Private variables
        private Coroutine _guidanceRoutineInst;
#endregion



#region Public methods and properties
        [ContextMenu("Launch")]
        public void Launch()
        {
            if(_guidanceRoutineInst != null)
            {
                var msg = "Attempt on repeated projectile launch. Guidance in progress. Aborting.";
                Debug.LogWarning(msg);
                return;
            }

            onLaunch.Invoke();
            StartGuidance();
        }
#endregion



#region Monobehavior methods
        private void OnCollisionEnter(Collision collision)
        {
            onCollision.Invoke();
        }
#endregion

        private void StartGuidance()
        {
            _guidanceRoutineInst = StartCoroutine(guidence.GuidanceRoutine(this.gameObject, target));
        }

        private void StopGuidance()
        {
            if(_guidanceRoutineInst != null)
            {
                StopCoroutine(_guidanceRoutineInst);
            }
        }
    }
}