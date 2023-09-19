using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Entropy.Isdle
{
    public abstract class UseableItem : MonoBehaviour
    {
        public UnityAction OnUseEvent;

        public float useCooldown;
        public float CooldownRemaining { get => _cd; set => _cd = value; }
        private float _cd;
        public abstract void UseItem();
        public abstract void AlternateUseItem();
        protected float lastTimeUsed;

        public float LastTimeUsed => lastTimeUsed - Time.realtimeSinceStartup;
        public bool CanBeUsed => CooldownRemaining <= 0f;
        public void StartCooldown() => _cd = useCooldown;

        public void FixedUpdate()
        {
            if (CooldownRemaining > 0f) { _cd -= Time.fixedDeltaTime; }
        }
        public void Orient(Transform item, OrientMode orientMode = OrientMode.OrientToMoveDirection)
        {
            if(orientMode == OrientMode.OrientToMouse)
            {
                item.right = GameManager.Instance.GetNormalizedMouseDirection(transform.position);
            }
            else if(orientMode == OrientMode.OrientToCardinalMouse)
            {
                item.right = GameManager.Instance.GetCardinalMouseDirection(transform.position);
            }
            else if(orientMode == OrientMode.OrientToMoveDirection)
            {
                Debug.LogWarning("Orient To Move Direction not yet implemented!!!");
            }
        }
    }
    public enum OrientMode
    {
        OrientToMouse,
        OrientToCardinalMouse,
        OrientToMoveDirection,
    }
}