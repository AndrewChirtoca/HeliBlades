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
    /// PlayersPawn class.
    /// </summary>
    public class PlayersPawn : MonoBehaviour
    {
#region Public serialized variables
        public GameObjectVariable leadRefStorage;
        public UnityEvent onPawnRegister;
#endregion



#region Private variables

#endregion



#region Public methods and properties
        public void RegisterPlayer(PlayersPawn player)
        {
            leadRefStorage.value = (player != null) ? player.gameObject : null;
            onPawnRegister.Invoke();
        }
#endregion



#region Monobehavior methods
        public void OnEnable()
        {
            RegisterPlayer(this);
        }

        public void OnDisable()
        {
            RegisterPlayer(null);
        }
#endregion
    }
}