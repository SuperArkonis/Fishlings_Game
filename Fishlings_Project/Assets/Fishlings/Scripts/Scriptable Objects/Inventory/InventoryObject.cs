using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Inventory", menuName = "Inventory System/Inventory")] //to create default item from editor menu
public class InventoryObject : ScriptableObject
{
    public List<InventorySlot> Container = new List<InventorySlot>();
    public void AddItem(ItemObject _item, int _amount)
    {
        bool hasItem = false;
        for(int i = 0; i < Container.Count; i++) //check if item already exists in inventory
        {
            if(Container[i].item == _item)
            {
                Container[i].AddAmount(_amount);
                hasItem = true;
                break;
            }
        }
        if(!hasItem)
        {
            Container.Add(new InventorySlot(_item, _amount));
        }
    }

    public void RemoveItem(ItemObject _item, int _amount = 1)
    {
        bool noItemsLeft = false;
        InventorySlot theslot = null;
        for(int i = 0; i < Container.Count; i++) //check if item already exists in inventory
        {
            if(Container[i].item == _item) //found item
            {
                theslot = Container[i];
                if (theslot.amount >= _amount)
                {
                    Container[i].AddAmount(-_amount);
                }
                if (theslot.amount == 0)
                    noItemsLeft = true;
                break;
            }
        }
        if(theslot != null && noItemsLeft)
        {
            Container.Remove(theslot);
        }
    }
}

[System.Serializable]
public class InventorySlot
{
    public ItemObject item;
    public int amount;
    public InventorySlot(ItemObject _item, int _amount)
    {
        item = _item;
        amount = _amount;
    }
    public void AddAmount(int value)
    {
        amount += value;
    }
}
