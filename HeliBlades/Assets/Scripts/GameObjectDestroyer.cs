//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 00:16:54
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// GameObjectDestroyer class.
    /// </summary>
    public class GameObjectDestroyer : MonoBehaviour
    {
#region Public serialized variables
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void DelayedDestroy(float time)
        {
            Destroy(gameObject, time);
        }
#endregion



#region Monobehavior methods
#endregion
    }
}