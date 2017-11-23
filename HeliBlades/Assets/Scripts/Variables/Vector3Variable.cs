//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    Insert datetime string (⇧⌘I or Ctrl+Shift+I)
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;



namespace HeliBlades
{
    /// <summary>
    /// Vector3Variable class.
    /// </summary>
    [CreateAssetMenu(fileName = "Vector3Variable", menuName = "Variables/Vector3")]
    public class Vector3Variable : ScriptableObject
    {
#region Public serialized variables
        public Vector3 value;
#endregion



#region Private variables
#endregion



#region Public methods and properties
        public void SetValue(Vector3 value)
        {
            this.value = value;
        }

        public void SetValue(Vector3Variable value)
        {
            this.value = value.value;
        }
#endregion



#region ScriptableObject methods
#endregion
    }
}