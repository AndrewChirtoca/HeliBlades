//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-24 01:46:27
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// TargetableEntity class.
    /// </summary>
    public class TargetableEntity : MonoBehaviour
    {
#region Public serialized variables
        public TargetablesRuntimeSet runtimeSet;
#endregion



#region Private variables

#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void OnEnable()
        {
            runtimeSet.Add(this);
        }

        private void OnDisable()
        {
            runtimeSet.Remove(this);
        }
#endregion
    }
}