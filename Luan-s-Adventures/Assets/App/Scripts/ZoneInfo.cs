using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ZoneInfo : MonoBehaviour
{
    public string info;
    bool inZone;
    void Update()
    {
        if (inZone)
        {
            CanvasManager.instance.CanvasGroupInfo(1, false, false);
            CanvasManager.instance.info = info;
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {

            inZone = true;
            
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        inZone = false;
        CanvasManager.instance.CanvasGroupInfo(0, false, false);
    }
}
