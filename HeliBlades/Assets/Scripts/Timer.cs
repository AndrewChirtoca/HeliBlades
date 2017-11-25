//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-25 19:03:16
//  Creator: Chirtoca Andrei <andrewchirtoca@gmail.com>
//
//===----------------------------------------------------------------------===//


using UnityEngine;
using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.Events;



namespace HeliBlades
{
    /// <summary>
    /// Timer class.
    /// </summary>
    public class Timer : MonoBehaviour
    {
#region Public serialized variables
        public UnityEvent onTimerExpired;
#endregion



#region Private variables
        private Coroutine _timerRoutineInst;
#endregion



#region Public methods and properties
        public void StartNewTimer(float totalDuration)
        {
            StopTimer();
            _timerRoutineInst = StartCoroutine(TimerRoutine(totalDuration));
        }

        public void StopTimer()
        {
            if(_timerRoutineInst != null)
            {
                StopCoroutine(_timerRoutineInst);
            }
        }
#endregion



#region Monobehavior methods
#endregion


        private IEnumerator TimerRoutine(float totalDuration)
        {
            float currentDuration = 0.0f;
            while(currentDuration < totalDuration)
            {
                currentDuration += Time.deltaTime;
                yield return null;
            }
            onTimerExpired.Invoke();
        }
    }
}