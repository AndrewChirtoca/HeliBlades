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
        public FollowLeaderConfig config;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void SetLeader(Transform newLeader)
        {
            leader = newLeader;
        }

        public void SetLeader(GameObject newLeader)
        {
            leader = newLeader.transform;
        }

        public void SetFollowConfig(FollowLeaderConfig newConfig)
        {
            config = newConfig;
        }
#endregion



#region Monobehavior methods
        private void Update()
        {
            Vector3 finalPos = (config.space == Space.Self) ?
                leader.TransformPoint(config.followOffset) :
                leader.position + config.followOffset;
            float t = config.moveRate * Time.deltaTime;
            transform.position = Vector3.Lerp(transform.position, finalPos, t);
        }
#endregion
    }
}