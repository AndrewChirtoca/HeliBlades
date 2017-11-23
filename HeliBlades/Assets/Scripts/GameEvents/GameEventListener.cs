//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-23 01:58:16
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
    /// GameEventListener class.
    /// </summary>
    public class GameEventListener : MonoBehaviour
    {
#region Public serialized variables
        public GameEvent followedEvent;
        public UnityEvent response;
#endregion



#region Private variables
        private void OnEnable()
        {
            followedEvent.RegisterListener(this);
        }

        private void OnDisable()
        {
            followedEvent.UnregisterListener(this);
        }

        public void OnEventRaised()
        {
            response.Invoke();
        }
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
#endregion
    }
}