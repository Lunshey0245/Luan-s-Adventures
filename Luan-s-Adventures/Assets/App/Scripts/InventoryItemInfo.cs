using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class InventoryItemInfo
{
    public string name;
    public int amount;
    public float price;
    public Sprite sprite;
    public int idx;

    public bool isConsumable;
    public bool isEquippable;
    public bool equipUnequip;
}
