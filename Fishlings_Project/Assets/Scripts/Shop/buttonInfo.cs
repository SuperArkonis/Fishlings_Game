using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class buttonInfo : MonoBehaviour
{
    public int ItemID;
    public TextMeshProUGUI PriceTxt;
    public TextMeshProUGUI QuantityTxt;
    public GameObject ShopManager;

    void Update()
    {
        PriceTxt.text = ShopManager.GetComponent<shopManager>().shopItems[2, ItemID].ToString();
        QuantityTxt.text = ShopManager.GetComponent<shopManager>().shopItems[3, ItemID].ToString();
    }
}
