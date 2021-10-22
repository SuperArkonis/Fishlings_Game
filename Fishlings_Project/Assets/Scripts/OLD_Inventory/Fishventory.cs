using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fishventory : MonoBehaviour
{
    public FishInventoryUI inventoryUI;
    public int stackSize = 10;
    public int inventorySize = 12;
    public Dictionary<FishType, int> _fishInventory;
    // Start is called before the first frame update
    void Start()
    {
        _fishInventory = new Dictionary<FishType, int>();
        //AddItem(FishType.BLUEFISH);
        //AddItem(FishType.REDFISH);
        //AddItem(FishType.YELLOWFISH);
        //AddItem(FishType.GREENFISH);
    }

    // Update is called once per frame
    void Update()
    {
        /*if (Input.GetButtonDown("Fire1"))
        {
            AddItem((FishType)Random.Range(0, 4));
        }*/
    }

    public void AddItem(FishType t)
    {
        if (CanAddItem(t))
        {
            if (_fishInventory.ContainsKey(t))
            {
                _fishInventory[t]++;
            }
            else
            {
                 _fishInventory[t] = 1;
            }
            inventoryUI.UpdateWithNewFish(t);
            //Print();
        }
    }
    public void RemoveItem(FishType t)
    {
        
    }

    //1. Does the 'key' already exist?
    //   yes?: is the stack full?
    //        yes?: no add.
    //        no?: add
    //   no?: is the inventory full
    //       yes: no add.
    //       no: create the key/value
    public bool CanAddItem(FishType t)
    {
        bool retval = false;
        if (_fishInventory.ContainsKey(t))
        {
            if (_fishInventory[t] >= stackSize)
            {
                retval = false;
            }
            else
            {
                retval = true;
            }
        }
        else
        {
            if (_fishInventory.Count >= inventorySize)
            {
                retval = false;
            }
            else
            {
                retval = true;
            }
        }
        return retval;
    }

    public void Print()
    {
        foreach (KeyValuePair<FishType, int> kvp in _fishInventory)
        {
            Debug.Log("[" + kvp.Key + "]: " + kvp.Value);
            Debug.Log(_fishInventory.Count);
        }
    }

}
