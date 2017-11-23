//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-23 02:09:49
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// GameEvent class.
    /// </summary>
    [CreateAssetMenu]
    public class GameEvent : ScriptableObject
    {
#region Public serialized variables
#endregion



#region Private variables
        private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();
#endregion



#region Public methods and properties
        [ContextMenu("Raise")]
        public void Raise()
        {
            for(int i = eventListeners.Count -1; i >= 0; i--)
            {
                eventListeners[i].OnEventRaised();
            }
        }

        public void RegisterListener(GameEventListener listener)
        {
            if (!eventListeners.Contains(listener))
            {
                eventListeners.Add(listener);
            }
        }

        public void UnregisterListener(GameEventListener listener)
        {
            if (eventListeners.Contains(listener))
            {
                eventListeners.Remove(listener);
            }
        }
#endregion



#region ScriptableObject methods
#endregion
    }
}