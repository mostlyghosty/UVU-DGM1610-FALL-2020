﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DecipheredNote : MonoBehaviour
{
    public Inventory sendToInventory;
    public DetectCollisions sendToDetectCollisions;
    public bool openNote = false;

    public GameObject inventory;

    public GameObject decipheredNote;

    // Start is called before the first frame update
    void Start()
    {
        decipheredNote.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(openNote == true)
        {
            openNote = false;

            //closes inventory
            Time.timeScale = 1;
            inventory.SetActive(false);
            sendToInventory.inventoryEnabled = false;

            //Opens Deciphered Note
            decipheredNote.SetActive(true);

            //checks to see if player has reads the deciphered note and sends that info to detect Collisions
            sendToDetectCollisions.decipheredNote = true;
        
        }

        if(Input.GetKeyDown(KeyCode.Tab))
        {
            decipheredNote.SetActive(false);
        }

    }
}