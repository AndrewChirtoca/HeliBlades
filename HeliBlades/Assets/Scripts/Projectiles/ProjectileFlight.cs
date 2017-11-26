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
using UnityEngine.Assertions;



namespace HeliBlades
{
    /// <summary>
    /// ProjectileFlight class.
    /// </summary>
    public class ProjectileFlight : MonoBehaviour
    {
#region Public serialized variables
        public float maxLifetime = 5.0f;
        public ProjectileGuide guidence;
        public UnityEvent onLaunch;
#endregion



#region Private variables
        private Coroutine _guidanceRoutineInst;
#endregion



#region Public methods and properties
        [ContextMenu("Launch")]
        public void Launch(GameObjectVariable target)
        {
            var msg = "Attempt on repeated launch of the same projectile.";
            Assert.IsTrue(_guidanceRoutineInst == null, msg);
            onLaunch.Invoke();
            StartGuidance(target);
        }
#endregion



#region Monobehavior methods
        private void Start()
        {
            Destroy(gameObject, maxLifetime);
        }
#endregion

        private void StartGuidance(GameObjectVariable target)
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