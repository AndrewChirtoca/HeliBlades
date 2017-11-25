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
        public GameObjectVariable selectedGameObject;
        public UnityEvent onTargetSelected;
        public UnityEvent onExitTargeting;
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
            selectedGameObject.value = (selectedTarget != null) ? selectedTarget.gameObject : null;
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
            onExitTargeting.Invoke();
        }

        [ContextMenu("Next Target")]
        public void NextTarget()
        {
            RemoveInvalidTargets();
            int targetIndex = _targetsInRange.IndexOf(selectedTarget);
            targetIndex = (targetIndex < _targetsInRange.Count - 1) ? ++targetIndex : 0;
            var newTarget = (_targetsInRange.Count > 0) ? _targetsInRange[targetIndex] : null;
            SelectTarget(newTarget);
        }

        [ContextMenu("Previous Target")]
        public void PreviousTarget()
        {
            RemoveInvalidTargets();
            int targetIndex = _targetsInRange.IndexOf(selectedTarget);
            targetIndex = (targetIndex > 0) ? --targetIndex : _targetsInRange.Count - 1;
            var newTarget = (_targetsInRange.Count > 0) ? _targetsInRange[targetIndex] : null;
            SelectTarget(newTarget);
        }
#endregion



#region Monobehavior methods
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.C))
            {
                EnterTargeting();
            }
            else if(Input.GetKeyDown(KeyCode.E))
            {
                ExitTargeting();
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow))
            {
                NextTarget();
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow))
            {
                PreviousTarget();
            }
        }
#endregion

        private void RemoveInvalidTargets()
        {
            for(int i = _targetsInRange.Count - 1; i >=0; i--)
            {
                if(_targetsInRange[i] == null)
                {
                    _targetsInRange.RemoveAt(i);
                }
            }
        }
    }
}