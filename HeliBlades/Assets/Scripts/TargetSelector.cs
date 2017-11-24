//===----------------------------------------------------------------------===//
//
//  vim: ft=cs tw=80
//
//  Date:    2017-11-24 02:01:02
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
    /// TargetSelector class.
    /// </summary>
    public class TargetSelector : MonoBehaviour
    {
#region Public serialized variables
        public TargetablesRuntimeSet targetablesSet;
        public float maxRange = 100.0f;
        public TargetableEntity selectedTarget;
        public UnityEvent onTargetSelected;
#endregion



#region Private variables
        private List<TargetableEntity> _targetsInRange;
#endregion



#region Public methods and properties
        public List<TargetableEntity> GetAllTargetsInRadius(float radius)
        {
            Vector3 selectorPos = transform.position;
            var result = new List<TargetableEntity>();
            int targetsCount = targetablesSet.items.Count;

            for(int i = 0; i < targetsCount; i++)
            {
                TargetableEntity target = targetablesSet.items[i];
                Vector3 targetPos = target.transform.position;
                float distance = Vector3.Distance(selectorPos, targetPos);

                if(distance < radius)
                {
                    result.Add(target);
                }
            }

            return result;
        }

        public void SelectTarget(TargetableEntity entity)
        {
            selectedTarget = entity;
            onTargetSelected.Invoke();
        }

        [ContextMenu("Enter Targeting")]
        public void EnterTargeting()
        {
            _targetsInRange = GetAllTargetsInRadius(maxRange);
            if(_targetsInRange.Count > 0)
            {
                SelectTarget(_targetsInRange[0]);
            }
        }

        [ContextMenu("Exit Targeting")]
        public void ExitTargeting()
        {
            SelectTarget(null);
        }

        [ContextMenu("Next Target")]
        public void NextTarget()
        {
            int targetIndex = _targetsInRange.IndexOf(selectedTarget);
            targetIndex = (targetIndex < _targetsInRange.Count - 1) ? ++targetIndex : 0;
            var newTarget = _targetsInRange[targetIndex];
            SelectTarget(newTarget);
        }


        [ContextMenu("Previous Target")]
        public void PreviousTarget()
        {
            int targetIndex = _targetsInRange.IndexOf(selectedTarget);
            targetIndex = (targetIndex > 0) ? --targetIndex : _targetsInRange.Count - 1;
            var newTarget = _targetsInRange[targetIndex];
            SelectTarget(newTarget);
        }
#endregion



#region Monobehavior methods
#endregion
    }
}