using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class tradeItem : MonoBehaviour
{
    TradeManager tradeManager;

    public string nameItem;
    public int amount;
    public float price;
    public Sprite sprite;
    public int idx;


    public TextMeshProUGUI nameItemTXT;
    public TextMeshProUGUI amountTXT;
    public TextMeshProUGUI priceTXT;
    public Image imageSprite;



    void Start()
    {
        tradeManager = FindObjectOfType<TradeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        nameItem = tradeManager.tradeItem[idx].name;
        amount = tradeManager.tradeItem[idx].amount;
        price = tradeManager.tradeItem[idx].price;
        sprite = tradeManager.tradeItem[idx].sprite;

        nameItemTXT.text = nameItem;
        amountTXT.text = "∞";
        priceTXT.text = "$" + price.ToString();
        imageSprite.sprite = sprite;
    }


    public void OnTrader()
    {
        if (CanvasManager.instance.openCloseTrade)
        {
            TradeManager.instance.idxItemTrader = idx;
        }
    }
}

