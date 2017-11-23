//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-24 00:55:43
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// RuntimeSet class.
    /// </summary>
    public abstract class RuntimeSet<T> : ScriptableObject
    {
#region Public serialized variables
        public List<T> items = new List<T>();
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void Add(T thing)
        {
            if (!items.Contains(thing))
            {
                items.Add(thing);
            }
        }

        public void Remove(T thing)
        {
            if (items.Contains(thing))
            {
                items.Remove(thing);
            }
        }
#endregion



#region ScriptableObject methods
#endregion
    }
}