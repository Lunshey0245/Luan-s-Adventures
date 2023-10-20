using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [Header("Inventory")]
    public CanvasGroup inventoryConteiner;
    public GameObject inventorySellButton;
    public bool openCloseInventory;
    public TextMeshProUGUI coinsTxt;
    GameController gameController;

    public TextMeshProUGUI priceItemInventory;
    public Image spriteItemInv;

    [Header("Trader")]
    public CanvasGroup traderConteiner;
    public bool openCloseTrade;
    public TextMeshProUGUI priceItemTrader;
    public Image spriteItemTrader;

    [Header("InfoCanvas")]
    public CanvasGroup information;
    public TextMeshProUGUI infoTxt;
    public string info;

    [Header("ButtonInventory")]
    public Image imageButtonInventory;
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
        gameController = FindObjectOfType<GameController>();
        CanvasGroupInventory(0, false, false);
        CanvasGroupTrader(0,false,false);
        CanvasGroupInfo(0, false, false);
    }

    void Update()
    {
        OnOpenInventory();
        OnOpenTrader();
        coinsTxt.text = gameController.coins.ToString();
        infoTxt.text = info.ToString();
    }

    public void OnOpenInventory()
    {
        if (openCloseTrade)
        {
            return;
        }
        if (openCloseInventory)
        {
            inventorySellButton.SetActive(false);
            CanvasGroupInventory(1, true, true);
            MakeButtonTransparent();
        }
        else
        {
            CanvasGroupInventory(0, false, false);
            imageButtonInventory.color = Color.white;
        }
    }
    public void OnOpenTrader()
    {
        if (openCloseInventory)
        {
            return;
        }
        if (openCloseTrade)
        {
            CanvasGroupInventory(1,true, true);
            inventorySellButton.SetActive(true);
            CanvasGroupTrader(1,true, true);
            MakeButtonTransparent();
        }
        else if (!openCloseTrade)
        {
            CanvasGroupInventory(0, false, false);
            inventorySellButton.SetActive(false);
            CanvasGroupTrader(0, false, false);
        }
    }
    public void OpenCloseTrade()
    {
        if (openCloseInventory)
        {
            return;
        }
        openCloseTrade = !openCloseTrade;
    }
    public void CanvasGroupInfo(float alpha, bool interactable, bool blocksRaycasts)
    {
        information.alpha = alpha;
        information.interactable = interactable;
        information.blocksRaycasts = blocksRaycasts;
    }

    public void CanvasGroupInventory(float alpha, bool interactable, bool blocksRaycasts)
    {
        inventoryConteiner.alpha = alpha;
        inventoryConteiner.interactable = interactable;
        inventoryConteiner.blocksRaycasts = blocksRaycasts;
    }


    public void CanvasGroupTrader(float alpha, bool interactable, bool blocksRaycasts)
    {
        traderConteiner.alpha = alpha;
        traderConteiner.interactable = interactable;
        traderConteiner.blocksRaycasts = blocksRaycasts;
    }

    public void OpenCloseInventory()
    {
        if (openCloseTrade)
        {
            return;
        }
        openCloseInventory = !openCloseInventory;
    }


    public void MakeButtonTransparent()
    {
        Color imageColor = imageButtonInventory.color;
        imageColor.a = 0.5f;
        imageButtonInventory.color = imageColor;
    }
}
