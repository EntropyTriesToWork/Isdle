using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Isdle
{
    public class Fists : UseableItem
    {
        public GameObject attack1, attack2;
        private bool _useAttack1;

        private void Update()
        {
            if(LastTimeUsed > 1f) { _useAttack1 = true; }
        }

        public override void UseItem()
        {
            if (_useAttack1) { Orient(attack1.transform, OrientMode.OrientToCardinalMouse); attack1.SetActive(true); _useAttack1 = false; }
            else { Orient(attack2.transform, OrientMode.OrientToCardinalMouse); attack2.SetActive(true); _useAttack1 = true; }
            lastTimeUsed = Time.realtimeSinceStartup;
        }

        public override void AlternateUseItem()
        {
            throw new System.NotImplementedException();
        }
    }
}