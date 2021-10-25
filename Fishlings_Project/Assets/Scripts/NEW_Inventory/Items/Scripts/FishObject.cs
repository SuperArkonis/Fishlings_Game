using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Fish Object", menuName = "Inventory System/Items/Fish")] //to create fish item from editor menu=
public class FishObject : ItemObject
{
    
    public void Awake()
    {
        type = ItemType.Fish;
    }
}
