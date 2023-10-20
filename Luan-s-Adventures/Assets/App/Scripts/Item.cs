using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Item : MonoBehaviour
{
    InventoryManager inventoryManager;

    public string nameItem;
    public int amount;
    public float price;
    public Sprite sprite;
    public int idx;
    public bool isConsumable;
    public bool isEquippable;

    public TextMeshProUGUI nameItemTXT;
    public TextMeshProUGUI amountTXT;
    public TextMeshProUGUI priceTXT;
    public Image imageSprite;
    public bool equipUnequip;

    bool canUse = true;
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {
        nameItem = inventoryManager.inventoryItem[idx].name;
        amount = inventoryManager.inventoryItem[idx].amount;
        price = inventoryManager.inventoryItem[idx].price;
        sprite = inventoryManager.inventoryItem[idx].sprite;

        nameItemTXT.text = nameItem;
        amountTXT.text = amount.ToString();
        if (!CanvasManager.instance.openCloseTrade)
        {
            priceTXT.text = "";
        }
        else
        {
            priceTXT.text = "$" + price.ToString();
        }
        imageSprite.sprite = sprite;

        if (CanvasManager.instance.openCloseTrade)
        {
            canUse = false;
        }
        else
        {
            canUse = true;
        }
    }

    public void OnTrader()
    {
        if (CanvasManager.instance.openCloseTrade)
        {
            TradeManager.instance.idxItemInventory = idx;
        }
    }

    public void OnInventory()
    {
        if (canUse)
        {
            if (isEquippable)
            {
                if (amount >= 1)
                {
                    inventoryManager.inventoryItem[idx].equipUnequip = !inventoryManager.inventoryItem[idx].equipUnequip;
                    if (inventoryManager.inventoryItem[idx].equipUnequip)
                    {
                        for (int i = 0; i < inventoryManager.inventoryItem.Length; i++)
                        {
                            if (i != idx)
                            {
                                inventoryManager.inventoryItem[i].equipUnequip = false;
                            }
                        }
                        ChangeEquipment.instance.Change(idx);
                    }
                    else
                    {
                        ChangeEquipment.instance.Change(0);
                    }
                }
            }
            if (isConsumable)
            {
                if (amount == 0)
                {
                    return;
                }
                inventoryManager.inventoryItem[idx].amount--;
            }
        }   
    }
}
