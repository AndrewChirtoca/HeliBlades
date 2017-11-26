//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 11:31:53
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;


namespace HeliBlades
{
    /// <summary>
    /// StructureExplosion class.
    /// </summary>
    public class StructureExplosion : MonoBehaviour
    {
#region Public serialized variables
        public GameObject effectPrefab;
#endregion



#region Private variables

#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void OnCollisionEnter(Collision collision)
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            var explosionInst = Instantiate(effectPrefab, pos, rot);
            Destroy(explosionInst, 3.0f);
            Destroy(gameObject);
        }
#endregion
    }
}