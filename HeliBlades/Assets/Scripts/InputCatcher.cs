//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-26 13:04:21
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using UnityEngine.Events;


[Serializable]
public struct KeyBinding
{
    public KeyCode key;
    public UnityEvent responce;
}


namespace HeliBlades
{
    /// <summary>
    /// InputCatcher class.
    /// </summary>
    public class InputCatcher : MonoBehaviour
    {
#region Public serialized variables
        public List<KeyBinding> bindings;
#endregion



#region Private variables
#endregion



#region Public methods and properties
#endregion



#region Monobehavior methods
        private void Update()
        {
            int bindCount = bindings.Count;
            for(int i = 0; i < bindCount; i++)
            {
                var binding = bindings[i];
                if(Input.GetKeyDown(bindings[i].key))
                {
                    binding.responce.Invoke();
                }
            }
        }
#endregion
    }
}