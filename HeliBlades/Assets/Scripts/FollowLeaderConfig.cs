//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 01:49:35
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// FollowLeaderConfig class.
    /// </summary>
    [CreateAssetMenu(fileName = "FollowLeaderConfig", menuName = "Configs/Follow Leader")]
    public class FollowLeaderConfig : ScriptableObject
    {
#region Public serialized variables
        public float moveRate;
        public Space space;
        public Vector3 followOffset;
#endregion



#region Private variables

#endregion



#region Public methods and properties
#endregion



#region ScriptableObject methods
#endregion
    }
}