using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpItem : MonoBehaviour
{
    InventoryManager inventoryManager;
    public int idx;
    public string info;

    bool canTakeOne;
    public bool canDestroy;
    void Start()
    {
        inventoryManager = FindObjectOfType<InventoryManager>();
    }

    // Update is called once per frame
    void Update()
    {

        if (canTakeOne)
        {
            CanvasManager.instance.CanvasGroupInfo(1, false, false);
            CanvasManager.instance.info = info;
            if (Input.GetKeyUp(KeyCode.E))
            {
                inventoryManager.inventoryItem[idx].amount++;
            }
        }

    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {         
            if (canDestroy)
            {
                inventoryManager.inventoryItem[idx].amount++;
                Destroy(this.gameObject);
            }
            else
            {
                canTakeOne = true;
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        canTakeOne = false;      
        CanvasManager.instance.CanvasGroupInfo(0, false, false);
    }
}
