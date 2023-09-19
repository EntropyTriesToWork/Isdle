using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Entropy.Isdle
{
    public class PlayerController : MonoBehaviour
    {
        public UseableItem currentlySelectedUseableItem;

        void Update()
        {
            if (Input.GetMouseButton(0) && currentlySelectedUseableItem != null)
            {
                if (currentlySelectedUseableItem.CanBeUsed) 
                {
                    currentlySelectedUseableItem.StartCooldown();
                    currentlySelectedUseableItem.UseItem();
                }
            }
        }
    }
}