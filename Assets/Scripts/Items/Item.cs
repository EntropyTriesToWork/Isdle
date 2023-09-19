using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

namespace Entropy.Isdle
{
    [System.Serializable]
    public class Item
    {
        [BoxGroup] public Rarity Rarity;
        [BoxGroup] [PreviewField] public Sprite icon;
        [BoxGroup] public string name, description;
        [BoxGroup] public bool stackable = true;
        [BoxGroup] public int maxStackSize = 99;
    }
    public enum Rarity
    {
        Scrap = 0, 
        Common = 1,
        Uncommon = 2,
        Rare = 3,
        Epic = 4,
        Legendary = 5,
        Godly = 6
    }
}