using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterExitPoint : MonoBehaviour
{
    public Transform exitPoint;
    PlayerController _playerController;

    bool isInTrigger = false;

    public GameObject cameraOnSite;
    public GameObject cameraOutSite;

    public Animator fadeInFadeOutAnim;


    public float timeToChangeLocation = 0.5f;
    bool goTime = false;
    void Start()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isInTrigger)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                goTime = true;

                fadeInFadeOutAnim.SetTrigger("FadeInOut");
            }
        }
        if (goTime)
        {
            timeToChangeLocation -= Time.deltaTime;
            if (timeToChangeLocation <= 0)
            {
                _playerController.transform.position = exitPoint.transform.position;
                cameraOnSite.SetActive(false);
                cameraOutSite.SetActive(true);
                goTime = false;
                timeToChangeLocation = 0.5f;
            }
        }


    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTrigger = true;
        }
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInTrigger = false;
        }
    }
}
