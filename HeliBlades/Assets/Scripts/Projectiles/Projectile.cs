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
    /// Projectile class.
    /// </summary>
    public class Projectile : MonoBehaviour
    {
#region Public serialized variables
        public ProjectileGuide guidence;
        public UnityEvent onLaunch;
        public UnityEvent onCollision;
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

        public void DestroyGameObject(GameObject gameObj)
        {
            Destroy(gameObj);
        }
#endregion



#region Monobehavior methods
        private void OnCollisionEnter(Collision collision)
        {
            onCollision.Invoke();
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