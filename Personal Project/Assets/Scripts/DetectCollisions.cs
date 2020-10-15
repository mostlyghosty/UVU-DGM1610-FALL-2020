﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollisions : MonoBehaviour
{
   private GameObject puzzlePiece;
   public string item;

   public Inventory sendToInventory;

   private int counter;

    void Start ()
    {
        //Initializes the counter
        counter = 0;
    }
    void Update()
    {
        //if you are still near the object and e is pressed
        if(puzzlePiece != null && Input.GetKeyDown(KeyCode.E))
        {
            //sends the object to the inventory script
            sendToInventory.slots[counter].text = item;
            Destroy(puzzlePiece);

            //moves to the next empty space in the slots array in the inventory script
            counter += 1;
            
        }
    }

    //If collision is entered sends the object collided with to an empty game object and gets the name and sends it to a text string
    void OnTriggerEnter(Collider other)
    {
    
            puzzlePiece = other.gameObject;
            item = other.gameObject.name;

    }

    //upon leaving the object's radius clears item and puzzle piece variables
    void OnTriggerExit(Collider other)
    {
        item = null;
        puzzlePiece = null;
    }


}