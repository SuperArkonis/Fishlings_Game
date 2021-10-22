using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ItemType
{
    Fish,
    Rod,
    Bait,
    Default
}
public abstract class ItemObject : ScriptableObject
{
    public GameObject prefab;
    public ItemType type;
    [TextArea(15,20)] //makes description easier to read in editor
    public string description;
}
