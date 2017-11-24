//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-24 03:48:40
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// ScriptableObjectVariable class.
    /// </summary>
    public abstract class ScriptableObjectVariable<T>: ScriptableObject
    {
#region Public serialized variables
        public T value;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void SetValue(T value)
        {
            this.value = value;
        }

        public void SetValue(ScriptableObjectVariable<T> value)
        {
            this.value = value.value;
        }
#endregion



#region ScriptableObject methods
#endregion
    }
}