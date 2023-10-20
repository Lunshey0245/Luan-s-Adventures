using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public InventoryItemInfo[] inventoryItem;

    public Transform inventory;
    public GameObject itemInv;
    void Start()
    {
        for (int i = 0; i < inventoryItem.Length; i++)
        {
            GameObject item = Instantiate(itemInv, inventory.transform);
            Item myDataItem = item.GetComponent<Item>();
            
            myDataItem.name = inventoryItem[i].name;
            myDataItem.amount = inventoryItem[i].amount;     
            myDataItem.price = inventoryItem[i].price;
            myDataItem.sprite = inventoryItem[i].sprite;
            myDataItem.idx  = inventoryItem[i].idx;
            myDataItem.isConsumable = inventoryItem[i].isConsumable;
            myDataItem.isEquippable = inventoryItem[i].isEquippable;
            myDataItem.equipUnequip = inventoryItem[i].equipUnequip;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
