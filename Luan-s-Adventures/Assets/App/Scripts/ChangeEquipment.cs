using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeEquipment : MonoBehaviour
{
    public static ChangeEquipment instance;
    public List<GameObject> equipment;
    private int equipmentActive;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        equipment = new List<GameObject>();
        foreach (Transform weapon in transform)
        {
            equipment.Add(weapon.gameObject);
        }

        for (int i = 0; i < equipment.Count; i++)
        {
            equipment[i].SetActive(i == equipmentActive);
        }
    }

    void Update()
    {

    }


    public void Change(int equip)
    {
        equipment[equipmentActive].SetActive(false);
        equipment[equip].SetActive(true);
        equipmentActive = equip;
    }
}
