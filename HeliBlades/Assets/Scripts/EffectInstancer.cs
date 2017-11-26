//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 01:40:43
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// EffectInstancer class.
    /// </summary>
    public class EffectInstancer : MonoBehaviour
    {
#region Public serialized variables
        public GameObject effectPrefab;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void SetPrefab(GameObject prefab)
        {
            effectPrefab = prefab;
        }

        public void InstatiateAndDestroy(float destroyDelay)
        {
            Vector3 pos = transform.position;
            Quaternion rot = transform.rotation;
            var instance = Instantiate(effectPrefab, pos, rot);
            Destroy(instance, destroyDelay);
        }
#endregion



#region Monobehavior methods
#endregion
    }
}