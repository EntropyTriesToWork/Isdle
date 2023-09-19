using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Entropy.Isdle
{
    [CreateAssetMenu(menuName = "Data/Item")]
    public class ItemData : ScriptableObject
    {
        [BoxGroup] public Item itemData;
    }
}