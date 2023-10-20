using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TraderController : MonoBehaviour
{
    CanvasManager canvasManager;
    bool canTrade;
    void Start()
    {
        canvasManager = FindObjectOfType<CanvasManager>();  
    }

    // Update is called once per frame
    void Update()
    {
        if (canTrade)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                canvasManager.OpenCloseTrade();
            }
        }
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTrade = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            canTrade = false;
            canvasManager.openCloseTrade = false;

        }
    }
}
