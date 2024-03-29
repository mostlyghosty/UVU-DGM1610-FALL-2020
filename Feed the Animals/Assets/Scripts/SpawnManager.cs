﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //The [] is to create an array, arrays begin counting at 0
    public GameObject[] animalPrefabs;

    //this points to a part of the array
    public int animalIndex;
    private float spawnRangeX = 15f;
    private float spawnPosZ = 15f;

    public float startDelay;

    public float spawnInterval;

    //calls to the function SpawRandomAnimals and runs the code at regular intervals
    void Start()
    {
        InvokeRepeating("SpawnRandomAnimals", startDelay, spawnInterval);
    }

    //void means it's not going to return any values
    void SpawnRandomAnimals()
    {
             //randomly generate animals at a random location
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX,spawnRangeX), 0, spawnPosZ);

            //Randomly selcts a value from the array
            int animalIndex = Random.Range(0,animalPrefabs.Length);

            //creates an instance of one of our animals
            Instantiate(animalPrefabs[animalIndex], spawnPos, animalPrefabs[animalIndex].transform.rotation);
    }
}
