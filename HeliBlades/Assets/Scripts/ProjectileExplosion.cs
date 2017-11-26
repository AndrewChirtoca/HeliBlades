//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 10:51:24
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
    /// ProjectileExplosion class.
    /// </summary>
    public class ProjectileExplosion : MonoBehaviour
    {
#region Public serialized variables
        public GameObject explosionPrefab;
        public List<ParticleSystem> trailingParticles;
#endregion



#region Private variables

#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void OnCollisionEnter(Collision collision)
        {
            int trailsCount = trailingParticles.Count;
            for(int i = 0; i < trailsCount; i++)
            {
                trailingParticles[i].transform.parent = null;
                trailingParticles[i].Stop();
                Destroy(trailingParticles[i].gameObject, 3.0f);
            }

            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            var explosionInst = Instantiate(explosionPrefab, pos, rot);
            Destroy(explosionInst, 3.0f);
            Destroy(gameObject);
        }
#endregion
    }
}