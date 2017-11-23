//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-23 02:47:32
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.AI;



namespace HeliBlades
{
    /// <summary>
    /// NewDestinationSetter class.
    /// </summary>
    public class NewDestinationSetter : MonoBehaviour
    {
#region Public serialized variables
        public NavMeshAgent agent;
        public Vector3Variable destinationLookup;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void LookupDestination()
        {
            agent.SetDestination(destinationLookup.value);
        }
#endregion



#region Monobehavior methods
#endregion
    }
}