﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
     //sets target for camera to follow
    public GameObject player;

    //defines offset of camera
    public Vector3 offset = new Vector3(0, 0, 0);

    //defines rotation of camera
    public Vector3 rotate = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        // Sets camera rotation before game starts
        transform.Rotate(rotate);
    }

    // Update is called once per frame
    void Update()
    {
        //tracks camera to player
        transform.position = player.transform.position + offset;
       
    }
}