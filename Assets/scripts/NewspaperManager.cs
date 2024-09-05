using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewspaperManager : MonoBehaviour
{
    [SerializeField]
    GameObject ui;

    [SerializeField]
    GameObject Letter;

    bool isopen = false;
    bool trigger = false;
    GameObject player;
    PlayerManager playerMovement;

    void Awake()
    {
        player = GameObject.Find("Capsule");
        playerMovement = player.GetComponent<PlayerManager>();
    }

    void Start()
    {
        ui.SetActive(false);
        Letter.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            if (trigger & !isopen)
            {
                Letter.SetActive(true);
                trigger = false;
                isopen = true;
                playerMovement.ChangeState(false);
            }

            if (trigger & isopen)
            {
                Letter.SetActive(false);
                trigger = false;
                isopen = false;
                playerMovement.ChangeState(true);
            }
        }
    }

    public bool GetState()
    {
        return isopen;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            trigger = false;
            ui.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ui.SetActive(true);
        }
    }
}
