using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DisplayInventory : MonoBehaviour
{
    public TextMeshProUGUI flavourText;
    public InventoryObject inventory;
    ItemObject currentSelectedItem;
    public int X_START;
    public int Y_START;
    public int X_SPACE_BETWEEN_ITEM;
    public int NUMBER_OF_COLUMN;
    public int Y_SPACE_BETWEEN_ITEM;
    Dictionary<InventorySlot, GameObject> itemsDisplayed = new Dictionary<InventorySlot, GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        CreateDisplay();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDisplay();
    }

    public void CreateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            /*
            var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform); //sets position, rotation, and parent
            obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
            obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            itemsDisplayed.Add(inventory.Container[i], obj);
            */
            CreateInventoryDisplayItem(inventory.Container[i], i);

        }
        currentSelectedItem = null;
    }
    public Vector3 GetPosition(int i)
    {
        return new Vector3(X_START + (X_SPACE_BETWEEN_ITEM * (i % NUMBER_OF_COLUMN)), Y_START + ((-Y_SPACE_BETWEEN_ITEM * (i/NUMBER_OF_COLUMN))), 0f);
    }

    public void UpdateDisplay()
    {
        for(int i = 0; i < inventory.Container.Count; i++)
        {
            if(itemsDisplayed.ContainsKey(inventory.Container[i]))
            {
                itemsDisplayed[inventory.Container[i]].GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
            }
            else
            {
                /*
                var obj = Instantiate(inventory.Container[i].item.prefab, Vector3.zero, Quaternion.identity, transform); //sets position, rotation, and parent
                obj.GetComponent<RectTransform>().localPosition = GetPosition(i);
                obj.GetComponentInChildren<TextMeshProUGUI>().text = inventory.Container[i].amount.ToString("n0");
                itemsDisplayed.Add(inventory.Container[i], obj);
                */
                CreateInventoryDisplayItem(inventory.Container[i], i);
            }
        }
        
    }

    void CreateInventoryDisplayItem(InventorySlot slot, int index)
    {
        var obj = Instantiate(slot.item.prefab, Vector3.zero, Quaternion.identity, transform); //sets position, rotation, and parent
        obj.GetComponent<RectTransform>().localPosition = GetPosition(index);
        obj.GetComponentInChildren<TextMeshProUGUI>().text = slot.amount.ToString("n0");
        itemsDisplayed.Add(slot, obj);

        //Add button function via code
        Button b = ((GameObject)obj).GetComponent<Button>();
        if (b != null)
        {
            b.onClick.AddListener( delegate { OnSelectItem( slot.item ); } );
            //Debug.Log(b.clickable); 
        }
    }

    void OnSelectItem(ItemObject item)
    {
        //Debug.Log(item.prefab);
        currentSelectedItem = item;
        flavourText.text = item.description;
    }

    private void OnApplicationQuit()
    {
        inventory.Container.Clear();//clears inventory when game quit
    }
}
