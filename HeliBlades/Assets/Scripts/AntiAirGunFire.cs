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
#endregion



#region Private variables
        private PlayersPawn _playersPawn;
        private Coroutine _shootingRoutine;
#endregion



#region Public methods and properties
        public void Aim(GameObjectVariable target)
        {
            Aim(target.value.transform);
        }

        public void Aim(Transform target)
        {
            yAxisRotator.enabled = true;
            xAxisRotator.enabled = true;
            yAxisRotator.SetLookTarget(target);
            xAxisRotator.SetLookTarget(target);
        }

        public void StopAim()
        {
            yAxisRotator.enabled = false;
            xAxisRotator.enabled = false;
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
        private void OnTriggerEnter(Collider other)
        {
            _playersPawn = other.GetComponent<PlayersPawn>();
            if(_playersPawn != null)
            {
                Aim(_playersPawn.transform);
                StartShooting();
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if(_playersPawn != null && _playersPawn.gameObject == other.gameObject)
            {
                StopAim();
                StopShooting();
            }
        }
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