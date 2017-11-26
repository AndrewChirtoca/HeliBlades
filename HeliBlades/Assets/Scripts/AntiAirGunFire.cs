//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 11:51:31
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;



namespace HeliBlades
{
    /// <summary>
    /// AntiAirGunFire class.
    /// </summary>
    public class AntiAirGunFire : MonoBehaviour
    {
#region Public serialized variables
        public GameObject firingEffectPrefab;
        public float maxEffectLifetime = 5.0f;
        public float fireDelay = 3.0f;
        public LookAt yAxisRotator;
        public LookAt xAxisRotator;
        public Transform launchPod;
        public GameObjectVariable playersTarget;
#endregion



#region Private variables
        private Coroutine _shootingRoutine;
#endregion



#region Public methods and properties
        public void Retaliate(GameObjectVariable target)
        {
            if(playersTarget.value != gameObject)
                return;
            Aim(target);
            StartShooting();
        }

        public void Aim(GameObjectVariable target)
        {
            Aim(target.value.transform);
        }

        public void Aim(Transform target)
        {
            yAxisRotator.SetLookTarget(target);
            xAxisRotator.SetLookTarget(target);
        }

        public void StartShooting()
        {
            StopShooting();
            _shootingRoutine = StartCoroutine(ShootingRoutine());
        }

        public void StopShooting()
        {
            if(_shootingRoutine != null)
            {
                StopCoroutine(_shootingRoutine);
            }
        }
#endregion



#region Monobehavior methods
#endregion


        private IEnumerator ShootingRoutine()
        {
            while(true)
            {
                yield return new WaitForSeconds(fireDelay);
                Vector3 pos = launchPod.position;
                Quaternion rot = launchPod.rotation;
                var effect = Instantiate(firingEffectPrefab, pos, rot);
                Destroy(effect, maxEffectLifetime);
            }
        }
    }
}