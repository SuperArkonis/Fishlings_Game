using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Bait Object", menuName = "Inventory System/Items/Bait")] //to create default item from editor menu
public class BaitObject : ItemObject
{
    public float baitBonus;
    public void Awake()
    {
        type = ItemType.Bait;
    }
}

