using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TradeManager : MonoBehaviour
{
    public static TradeManager instance;
    public TradeItemInfo[] tradeItem;

    public GameObject tradeItemSlot;
    public Transform tradeTransform;


    public int idxItemTrader;
    public int idxItemInventory;

    CanvasManager canvasManager;
    InventoryManager inventoryManager;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();
        inventoryManager = FindObjectOfType<InventoryManager>();
        for (int i = 0; i < tradeItem.Length; i++)
        {
            GameObject item = Instantiate(tradeItemSlot, tradeTransform.transform);
            tradeItem myDataItem = item.GetComponent<tradeItem>();

            myDataItem.name = tradeItem[i].name;
            myDataItem.price = tradeItem[i].price;
            myDataItem.sprite = tradeItem[i].sprite;
            myDataItem.idx = tradeItem[i].idx;
        }
    }

    // Update is called once per frame
    void Update()
    {
        canvasManager.spriteItemInv.sprite = inventoryManager.inventoryItem[idxItemInventory].sprite;
        canvasManager.spriteItemTrader.sprite = tradeItem[idxItemTrader].sprite;
        canvasManager.priceItemInventory.text = inventoryManager.inventoryItem[idxItemInventory].price.ToString();
        canvasManager.priceItemTrader.text = tradeItem[idxItemTrader].price.ToString();
    }


    public void Buy()
    {
        if (GameController.instance.coins >= tradeItem[idxItemTrader].price)
        {
            GameController.instance.coins -= tradeItem[idxItemTrader].price;
            inventoryManager.inventoryItem[idxItemTrader].amount++;
        }
        else
        {
            Debug.Log("NO TIENE DINERO");
        }
    }


    public void Sell()
    {
        if (inventoryManager.inventoryItem[idxItemInventory].amount > 0)
        {
            inventoryManager.inventoryItem[idxItemInventory].amount--;
            GameController.instance.coins += inventoryManager.inventoryItem[idxItemInventory].price;
            if (inventoryManager.inventoryItem[idxItemInventory].amount == 0)
            {
                if (inventoryManager.inventoryItem[idxItemInventory].equipUnequip)
                {
                    ChangeEquipment.instance.Change(0);
                }
            }
        }
        else
        {
            Debug.Log("No tiene mas Items");
        }
    }
}
