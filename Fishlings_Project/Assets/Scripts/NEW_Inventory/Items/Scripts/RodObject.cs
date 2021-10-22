using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Rod Object", menuName = "Inventory System/Items/Rod")] //to create default item from editor menu
public class RodObject : ItemObject
{
    public float hookBonus;
    public void Awake()
    {
        type = ItemType.Rod;
    }
}
