//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 00:02:21
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
    /// FollowLeader class.
    /// </summary>
    public class FollowLeader : MonoBehaviour
    {
#region Public serialized variables
        public Transform leader;
        public float moveRate;
        public Space space;
        public Vector3 followOffset;
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void Update()
        {
            Vector3 finalPos = (space == Space.Self) ?
                leader.TransformPoint(followOffset) :
                leader.position + followOffset;
            float t = moveRate * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, finalPos, t);
        }
#endregion
    }
}