//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 02:46:51
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;



namespace HeliBlades
{
    /// <summary>
    /// DefaultCameraLeader class.
    /// </summary>
    public class DefaultCameraLeader : MonoBehaviour
    {
#region Public serialized variables
        public GameObjectVariable leadRefStorage;
        public UnityEvent onObjectRegistered;
#endregion



#region Private variables

#endregion



#region Public methods and properties
        public void RegisterCameraLeader(DefaultCameraLeader leader)
        {
            leadRefStorage.value = (leader != null) ? leader.gameObject : null;
            onObjectRegistered.Invoke();
        }
#endregion



#region Monobehavior methods
        public void OnEnable()
        {
            RegisterCameraLeader(this);
        }

        public void OnDisable()
        {
            RegisterCameraLeader(null);
        }
#endregion
    }
}