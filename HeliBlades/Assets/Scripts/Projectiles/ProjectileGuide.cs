//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 15:48:03
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
    /// ProjectileGuide class.
    /// </summary>
    public abstract class ProjectileGuide : ScriptableObject
    {
#region Public serialized variables
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region ScriptableObject methods
#endregion


        public virtual IEnumerator GuidanceRoutine(GameObject projInst, GameObjectVariable target)
        {
            yield return null;
        }
    }
}